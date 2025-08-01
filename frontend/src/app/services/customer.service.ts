import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Customer
{
    custid: number;
    customerName: string;
    lastOrderDate: Date;
    nextPredictedOrder: Date;
}

@Injectable({
  providedIn: 'root'
})

export class CustomerService {
  
  private apiUrl = "http://localhost:5016/";

  constructor(private http: HttpClient) { }

  salesDatePredictionAsync(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.apiUrl + "api/Customers/salesDatePredictionAsync");
  }
}
