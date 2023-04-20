import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEstateComponent } from './add-estate/add-estate.component';
import { CompanyDetailComponent } from './company-detail/company-detail.component';
import { CompanyListComponent } from './company-list/company-list.component';
import { CompanyProfileComponent } from './company-profile/company-profile.component';
import { CostInfoComponent } from './cost-info/cost-info.component';
import { EstateDetailComponent } from './estate-detail/estate-detail.component';
import { EstateListComponent } from './estate-list/estate-list.component';
import { EstateComponent } from './estate/estate.component';
import { FieldDetailComponent } from './field-detail/field-detail.component';
import { FieldInfoComponent } from './field-info/field-info.component';
import { FieldProductionComponent } from './field-production/field-production.component';
import { HomeComponent } from './home/home.component';
import { LaborInfoComponent } from './labor-info/labor-info.component';
import { LoginComponent } from './login/login.component';
import { CloneComponent } from './utility/clone/clone.component';
import { CostCategoryComponent } from './utility/cost-category/cost-category.component';
import { CostItemComponent } from './utility/cost-item/cost-item.component';
import { CountryComponent } from './utility/country/country.component';
import { CropCategoryComponent } from './utility/crop-category/crop-category.component';
import { EstablishmentComponent } from './utility/establishment/establishment.component';
import { FinancialYearComponent } from './utility/financial-year/financial-year.component';
import { MembershipComponent } from './utility/membership/membership.component';
import { StateComponent } from './utility/state/state.component';
import { TownComponent } from './utility/town/town.component';
import { UtilityComponent } from './utility/utility.component';
import { HomeLayoutComponent } from './_layout/home-layout/home-layout.component';
import { LoginLayoutComponent } from './_layout/login-layout/login-layout.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  {
    path: 'login',
    component: LoginLayoutComponent,
    children: [{ path: '', component: LoginComponent }],
  },
  {
    path: 'e-estate',
    component: HomeLayoutComponent,
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'company-profile', component: CompanyProfileComponent },
      { path: 'company-list', component: CompanyListComponent },
      { path: 'company-profile/:id', component: CompanyDetailComponent },
      { path: 'estate', component: EstateComponent },
      { path: 'add-estate', component: AddEstateComponent },
      { path: 'add-estate/:id', component: AddEstateComponent },
      { path: 'estate-list', component: EstateListComponent },
      { path: 'estate-detail/:id', component: EstateDetailComponent },
      { path: 'field-info', component: FieldInfoComponent },
      { path: 'field-detail/:id', component: FieldDetailComponent },
      { path: 'field-production', component: FieldProductionComponent },
      { path: 'labor-info', component: LaborInfoComponent },
      { path: 'cost-info', component: CostInfoComponent },
      {
        path: 'utilities',
        component: UtilityComponent,
        children: [
          { path: 'state', component: StateComponent },
          { path: 'financialYear', component: FinancialYearComponent },
          { path: 'membershipType', component: MembershipComponent },
          { path: 'establishment', component: EstablishmentComponent },
          { path: 'town', component: TownComponent },
          { path: 'crop-category', component: CropCategoryComponent },
          { path: 'clone', component: CloneComponent },
          { path: 'country', component: CountryComponent },
          { path: 'cost-category', component: CostCategoryComponent },
          { path: 'cost-item', component: CostItemComponent },
        ],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
