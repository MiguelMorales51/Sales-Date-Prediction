import { Component, OnInit } from '@angular/core';
import { AfterViewInit, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Customer, CustomerService } from './services/customer.service';
import { ChangeDetectionStrategy } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { OrderComponent } from './features/order/order.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatTableModule, MatSortModule, MatPaginatorModule, MatIconModule, OrderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class AppComponent implements AfterViewInit {
 @ViewChild(OrderComponent) childOrder!: OrderComponent;

  displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrder', 'viewOrder', 'addNewOrder'];
  customers: Customer[] = [];
  dataSource: MatTableDataSource<Customer> = new MatTableDataSource(this.customers);

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort)
  sort!: MatSort;

  constructor(private customerService: CustomerService) {
    this.customerService.salesDatePredictionAsync().subscribe({
      next: (data) => this.llenarCustomer(data),
      error: (err) => console.error('Error to get customers', err)
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  llenarCustomer(data : Array<Customer>){
    for (let obj of data) {
      //A pesar de no tomar el tipo; crear objeto nuevo
      this.customers.push(this.newCustomer(obj));
    }
    this.dataSource.data = this.customers;
  }

  newCustomer(obj : Customer) : Customer {
    return {
      custid: obj.custid,
      customerName: obj.customerName,
      lastOrderDate: obj.lastOrderDate,
      nextPredictedOrder: obj.nextPredictedOrder
    };
  }

  viewOrdersByCustomer(custid: number) {
    this.childOrder.viewOrdersByCustomer(custid);
  }
}

