import { Component, OnInit } from '@angular/core';
import {AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {NgClass, NgIf} from "@angular/common";
import { Router } from '@angular/router';
import {PersonalDetails} from "../models/personal-details";
import {UserService} from "../services/user.service";

@Component({
  selector: 'app-step1',
  templateUrl: './step-one.component.html',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    NgIf,
    NgClass
  ],
  styleUrls: ['./step-one.component.css']
})
export class StepOneComponent implements OnInit {
  step1Form: FormGroup;
  personalDetails : PersonalDetails;

  constructor(private fb: FormBuilder, private router: Router, private userService : UserService) {
    this.step1Form = this.fb.group({});
    this.personalDetails = userService.personalDetails;
  }

  ngOnInit(): void {
    this.step1Form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{3,}$/)]],
      confirmPassword: ['', [Validators.required, this.matchPassword.bind(this)]],
      agree: [false, Validators.requiredTrue]
    });
  }

  get formControls() { return this.step1Form.controls; }

  matchPassword(control: AbstractControl): { [key: string]: boolean } | null {
    if(this.step1Form.controls === undefined || this.step1Form.controls.password === undefined)
      return null;

    const password = this.step1Form.controls.password.value;
    const confirmPassword = control.value;
    if (password !== confirmPassword)
      return { 'passwordMismatch': true };

    return null;
  }

  validateForm() {
    Object.keys(this.step1Form.controls).forEach(field => {
      const control = this.step1Form.controls[field];
      control.markAsTouched({ onlySelf: true });
    });
  }

  onNext() {
    this.validateForm();
    if (this.step1Form.invalid) {
      return;
    }

    this.personalDetails.email = this.step1Form.controls.email.value;
    this.personalDetails.password = this.step1Form.controls.password.value;

    this.router.navigate(['/', 'step2']);
  }
}

