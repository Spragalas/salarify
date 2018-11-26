import { Component, Inject } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material";
import { FormBuilder } from "@angular/forms";

@Component({
  selector: 'edit-dialog',
  templateUrl: 'editdialog.component.html',
})
export class EditDialog {
  public satisfactionForm: any = {};

  constructor(
    public dialogRef: MatDialogRef<EditDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder) {

    this.satisfactionForm = this.fb.group({
      options: [data.employee.SatisfactionScore]
    });
    console.log(this.myForm);
    console.log(this.data);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
