import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonFormComponent } from './components/person/person-form/person-form.component';
import { PersonListComponent } from './components/person/person-list/person-list.component';

const routes: Routes = [
  { path: '',   redirectTo: '/persons', pathMatch: 'full' },
  { path: 'persons',        component: PersonListComponent },
  { path: 'person',        component: PersonFormComponent  },
  { path: 'person/:id',        component: PersonFormComponent  },
  { path: '**', component: PersonListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
