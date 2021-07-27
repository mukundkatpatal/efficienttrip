import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {

  tournamentForm: FormGroup;

  constructor(private fb: FormBuilder) { 
  	this.createForm();
  }

  ngOnInit(): void {
  }

  createForm(){
  	this.tournamentForm = this.fb.group({
  		name: '',
  		place: '',
  		startd: '',
  		endd: '',
  		rounds: '',
  		category: '',
  		website: ''
  	});
  }

  onSubmit(){
  	console.log(this.tournamentForm.value);
  	this.tournamentForm.reset();
  }

}
