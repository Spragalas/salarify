import { Component, OnInit } from '@angular/core';
import { RestService } from '../rest.service'
import { MatDialog } from '@angular/material';
import { EditDialog } from './components/editDialog/editDialog.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  title = "Employees";
  employees: any = [];
  constructor(public rest: RestService, public dialog: MatDialog) { }
  ngOnInit() {
    this.getEmployees();
  }
  getEmployees() {
    this.rest.getEmployees()
      .subscribe(employees => {
        this.employees = employees;
      })
  }

  showEditDialog(employee: any): void {
    const dialogRef = this.dialog.open(EditDialog, {
      data: { employee: employee }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.rest.updateSatisfaction(employee.ID, result).subscribe(() => this.getEmployees());
    });
  }
}
