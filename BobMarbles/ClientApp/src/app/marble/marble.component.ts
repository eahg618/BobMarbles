import { Component, OnInit } from '@angular/core';
import { Marble } from '../shared/marble.model';
import { MarbleService } from '../shared/marble.service';

@Component({
  selector: 'app-marble',
  templateUrl: './marble.component.html',
  styleUrls: ['./marble.component.css']
})
export class MarbleComponent implements OnInit {


  constructor(public service: MarbleService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Marble) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    this.service.deleteMarble(id)
      .subscribe(
        res => {
          this.service.refreshList();
        },
        err => { console.log(err) }
      )
  }
} 
