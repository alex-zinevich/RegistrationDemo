import { Component } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { LocationDetails } from "../models/location-details";
import { UserService } from "../services/user.service";
import {NgClass, NgForOf, NgIf} from "@angular/common";

@Component({
  selector: 'app-step-two',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormsModule,
    NgForOf,
    NgIf,
    NgClass
  ],
  templateUrl: './step-two.component.html',
  styleUrl: './step-two.component.css'
})
export class StepTwoComponent {
  countries: Array<any>;
  provinces: Array<any>;
  locationDetails: LocationDetails;

  isCountryTouched: boolean;
  isProvinceTouched: boolean;

  constructor(private userService : UserService) {
    this.locationDetails = userService.locationDetails;
    this.countries = [];
    this.provinces = [{"id": undefined, "name": "Please select country first"}];
    this.isCountryTouched = false;
    this.isProvinceTouched = false;
  }

  ngOnInit(): void {
    this.getCountries();
  }

  getCountries(){
    this.userService.getAllCountries()
      .subscribe({
        next: (response: Array<any>) => {
          this.countries = response;
          this.countries.unshift({"id": undefined, "name": "Select country"});
          this.locationDetails.countryId = undefined;
        },
        error: (error: string) => console.log('Error getting countries: ' + error)
      });
  }

  getProvinces(countryId: number) {
    this.userService.getProvinces(countryId)
      .subscribe({
        next: (response: Array<any>) => {
          this.provinces = response;
          this.provinces.unshift({"id": undefined, "name": "Select province"});
          this.locationDetails.provinceId = undefined;
        },
        error: (error: string) => console.log('Error getting provinces: ' + error)
      });
  }

  onCountrySelected(value:string) {
    this.getProvinces(parseInt(value));
  }

  onCountryTouched() {
    this.isCountryTouched = true;
  }

  onProvinceTouched() {
    this.isProvinceTouched = true;
  }

  validate(): boolean {
    this.isCountryTouched = true;
    this.isProvinceTouched = true;

    if (!this.locationDetails.countryId)
      return false;

    if(!this.locationDetails.provinceId)
      return false;

    return true;
  }

  save() {
    if(!this.validate())
      return;

    this.userService.createUser().subscribe({
      next:() => alert("Success!"),
      error: () => alert("Error!")
    });
  }
}
