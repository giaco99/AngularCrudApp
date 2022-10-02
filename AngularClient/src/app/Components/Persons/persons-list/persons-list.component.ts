import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Person } from 'src/app/Models/Person.model';
import {PersonsService} from 'src/app/Services/persons.service'
import {ChangeDetectorRef} from '@angular/core';

@Component({
  selector: 'app-persons-list',
  templateUrl: './persons-list.component.html',
  styleUrls: ['./persons-list.component.scss']
})
export class PersonsListComponent implements OnInit {

  persons: Person[] =  [];

  constructor(private personService:  PersonsService,private cdr: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.personService.GetAllPersons()
    .subscribe(
      {
        next: (persons) =>{
          this.persons = persons;
          console.log(persons);
          this.cdr.detectChanges();
      },
      error: (response) =>{console.log(response);}
      })
    }
}
