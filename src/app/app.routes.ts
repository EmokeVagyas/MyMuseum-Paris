import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AllMuseumsComponent } from './all-museums/all-museums.component';
import { MuseumComponent } from './museum/museum.component';
import { ForKidsComponent } from './for-kids/for-kids.component';
import { SeasonalComponent } from './seasonal/seasonal.component';
import { QuestionnaireComponent } from './questionnaire/questionnaire.component';

export const routes: Routes = [
    {path: '', redirectTo: '/home', pathMatch:'full'},
    {path: 'home', component: HomeComponent},
    {path: 'all-museums', component: AllMuseumsComponent},
    {path: 'museum/:id', component: MuseumComponent},
    {path: 'for-kids', component: ForKidsComponent},
    {path: 'seasonal', component: SeasonalComponent},
    {path: 'questionnaire', component: QuestionnaireComponent},    
];
