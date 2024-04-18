import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StepOneComponent } from './step-one/step-one.component';
import { StepTwoComponent } from './step-two/step-two.component';

export const routes: Routes = [
  { path: 'step1', component: StepOneComponent },
  { path: 'step2', component: StepTwoComponent },
  { path: '', redirectTo: '/step1', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

