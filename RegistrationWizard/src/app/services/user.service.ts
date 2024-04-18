import { Injectable } from '@angular/core';
import { PersonalDetails } from "../models/personal-details";
import { LocationDetails } from "../models/location-details";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly API_URL: string = "https://localhost:7194"

  personalDetails : PersonalDetails;
  locationDetails : LocationDetails;

  constructor(private httpClient: HttpClient) {
    this.personalDetails = new PersonalDetails();
    this.locationDetails = new LocationDetails();
  }

  getAllCountries () {
    return this.httpClient.get<any[]>(this.API_URL + '/countries/all');
  }

  getProvinces(countryId: number) {
    return this.httpClient.get<any[]>(this.API_URL + '/countries/' + countryId + '/provinces');
  }

  createUser() {
    const data = {
      "email": this.personalDetails.email,
      "password": this.personalDetails.password,
      "countryId": this.locationDetails.countryId,
      "provinceId": this.locationDetails.provinceId
    }

    return this.httpClient.post<any>(this.API_URL + '/users/create', data);
  }
}
