import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Person } from 'src/app/Models/Person.model';
import { PersonsService } from 'src/app/Services/persons.service';
import { LocalizationService } from 'src/app/Services/localization.service';

@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrls: ['./add-person.component.scss']
})
export class AddPersonComponent implements OnInit {

  addPerson: Person = {
    id: '',
    name: '',
    surname: '',
    gender: '',
    birthDate: '',
    birthPlace: '',
    taxCode: '',
    province:''
  }

  provinces: string[] =  [];

  municipalities: string[] = [];

  constructor(
    private personService : PersonsService,
    private localizationService : LocalizationService,
    private router : Router) { }

  ngOnInit(): void {
    this.localizationService.GetDistinctProvinces()
    .subscribe(
      {
        next: (provinces) =>{
          this.provinces = provinces;
          console.log(provinces);
      },
      error: (response) =>{console.log(response);}
      })
  }

  onChangeProvince(){
    this.localizationService.GetMunicipalitiesFromProvince(this.addPerson.province)
    .subscribe(
      {
        next: (municipalities) =>{
          this.municipalities = municipalities;
          console.log(municipalities);
      },
      error: (response) =>{console.log(response);}
      })
  }

  AddPerson()
  {
    this.personService.AddPerson(this.addPerson)
    .subscribe({
      next:(addedPerson) =>
      {
        console.log(addedPerson);
        this.router.navigate(['/persons']);
      }
    })
  }
}
