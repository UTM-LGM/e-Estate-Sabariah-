import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DatePipe } from '@angular/common';

import { NgPipesModule } from 'ngx-pipes';
import { AppRoutingModule } from './app-routing.module';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { MatTabsModule } from '@angular/material/tabs';
import { MatDialogModule } from '@angular/material/dialog';
import { NgxSkeletonLoaderModule } from 'ngx-skeleton-loader';
import { NgxPaginationModule } from 'ngx-pagination';

import { AppComponent } from './app.component';
import { LoginLayoutComponent } from './_layout/login-layout/login-layout.component';
import { LoginComponent } from './login/login.component';
import { HomeLayoutComponent } from './_layout/home-layout/home-layout.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { CompanyProfileComponent } from './company-profile/company-profile.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { HomeComponent } from './home/home.component';
import { CompanyListComponent } from './company-list/company-list.component';
import { FormsModule } from '@angular/forms';
import { CompanyDetailComponent } from './company-detail/company-detail.component';
import { EstateComponent } from './estate/estate.component';
import { AddEstateComponent } from './add-estate/add-estate.component';
import { UtilityComponent } from './utility/utility.component';
import { StateComponent } from './utility/state/state.component';
import { FinancialYearComponent } from './utility/financial-year/financial-year.component';
import { MembershipComponent } from './utility/membership/membership.component';
import { EstablishmentComponent } from './utility/establishment/establishment.component';
import { TownComponent } from './utility/town/town.component';
import { EstateListComponent } from './estate-list/estate-list.component';
import { EstateDetailComponent } from './estate-detail/estate-detail.component';
import { FieldInfoComponent } from './field-info/field-info.component';
import { CropCategoryComponent } from './utility/crop-category/crop-category.component';
import { CloneComponent } from './utility/clone/clone.component';
import { LaborInfoComponent } from './labor-info/labor-info.component';
import { FieldDetailComponent } from './field-detail/field-detail.component';
import { CountryComponent } from './utility/country/country.component';
import { CostCategoryComponent } from './utility/cost-category/cost-category.component';
import { CostItemComponent } from './utility/cost-item/cost-item.component';
import { CostInfoComponent } from './cost-info/cost-info.component';
import { DirectCostComponent } from './cost-info/direct-cost/direct-cost.component';
import { IndirectCostComponent } from './cost-info/indirect-cost/indirect-cost.component';
import { FieldProductionComponent } from './field-production/field-production.component';
import { FieldProductionDetailComponent } from './field-production-detail/field-production-detail.component';
import { MatDialog } from '@angular/material/dialog';
import { UserActivityLogInterceptor } from './_interceptor/userActivityLog.interceptor';
import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    AppComponent,
    LoginLayoutComponent,
    LoginComponent,
    HomeLayoutComponent,
    SidenavComponent,
    CompanyProfileComponent,
    SpinnerComponent,
    HomeComponent,
    CompanyListComponent,
    CompanyDetailComponent,
    EstateComponent,
    AddEstateComponent,
    UtilityComponent,
    StateComponent,
    FinancialYearComponent,
    MembershipComponent,
    EstablishmentComponent,
    TownComponent,
    EstateListComponent,
    EstateDetailComponent,
    FieldInfoComponent,
    CropCategoryComponent,
    CloneComponent,
    LaborInfoComponent,
    FieldDetailComponent,
    CountryComponent,
    CostCategoryComponent,
    CostItemComponent,
    CostInfoComponent,
    DirectCostComponent,
    IndirectCostComponent,
    FieldProductionComponent,
    FieldProductionDetailComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatToolbarModule,
    MatSidenavModule,
    MatIconModule,
    MatButtonModule,
    BrowserAnimationsModule,
    MatDividerModule,
    HttpClientModule,
    Ng2SearchPipeModule,
    FormsModule,
    MatTabsModule,
    MatDialogModule,
    NgxSkeletonLoaderModule,
    NgxPaginationModule,
    NgPipesModule,
    MatSnackBarModule
  ],
  providers: [DatePipe, MatDialog, {
    provide: HTTP_INTERCEPTORS,
    useClass: UserActivityLogInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent],
})
export class AppModule {}
