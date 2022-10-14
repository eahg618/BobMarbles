import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Marble } from '../../shared/marble.model';
import { MarbleService } from '../../shared/marble.service';

@Component({
  selector: 'app-marbleform',
  templateUrl: './marbleform.component.html',
  styleUrls: ['./marbleform.component.css']
})
export class MarbleformComponent implements OnInit {

  constructor(public service: MarbleService) {
  }
  ngOnInit(): void {
  }
  onSubmit(form: NgForm) {
    if (this.service.formData.id == 0) //we will use the id as identifier for updating or insertion
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }
  insertRecord(form: NgForm) {
    this.service.postMarble().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    );
  }
  updateRecord(form: NgForm) {
    this.service.putMarble().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    );
  }
  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new Marble();
  }
}
