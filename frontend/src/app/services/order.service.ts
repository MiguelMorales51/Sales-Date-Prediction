import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Order
{
    orderid: number;
    requireddate: Date;
    shippeddate: Date;
    shipname: string;
    shipaddress: string;
    shipcity: string;
}

@Injectable({
  providedIn: 'root'
})

export class OrderService {

  private apiUrl = "http://localhost:5016/";

  constructor(private http: HttpClient) { }

  getClientOrders(id: number) : Observable<Order[]> {
    return this.http.get<Order[]>(this.apiUrl + "api/Orders/getClientOrders/" + id + "");
  }
}
