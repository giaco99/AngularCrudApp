import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddPersonComponent } from './Components/Persons/add-person/add-person.component';
import { EditPersonComponent } from './Components/Persons/edit-person/edit-person.component';
import { PersonsListComponent } from './Components/Persons/persons-list/persons-list.component';

const routes: Routes = [
  {
    path: '',
    component: PersonsListComponent
  },
  {
    path: 'persons',
    component: PersonsListComponent
  },
  {
    path: 'persons/add',
    component: AddPersonComponent
  },
  {
    path: 'persons/edit/:id',
    component: EditPersonComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
