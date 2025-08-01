import { Component } from '@angular/core';
import { AfterViewInit, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Order, OrderService } from '../../services/order.service';


@Component({
  selector: 'app-order',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatTableModule, MatSortModule, MatPaginatorModule],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})

export class OrderComponent implements AfterViewInit {
  custid: number = 0;
  displayedColumns: string[] = [''];
  orders: Order[] = [];
  dataSource: MatTableDataSource<Order> = new MatTableDataSource(this.orders);
  
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort)
  sort!: MatSort;

  constructor() {}

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  viewOrdersByCustomer(custid: number) {
    //
  }

}
