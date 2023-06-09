﻿// <auto-generated />
using System;
using E_EstateV2_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_EstateV2_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230405025740_estateIdCostAmount")]
    partial class estateIdCostAmount
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_EstateV2_API.Models.Clone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("cloneCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cloneName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("clones");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("managerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("town")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("companies");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.Cost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("costCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("costSubcategory1Id")
                        .HasColumnType("int");

                    b.Property<int>("costSubcategory2Id")
                        .HasColumnType("int");

                    b.Property<int>("costTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("isMature")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("costCategoryId");

                    b.HasIndex("costSubcategory1Id");

                    b.HasIndex("costSubcategory2Id");

                    b.HasIndex("costTypeId");

                    b.ToTable("costs");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.CostAmount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<int>("costId")
                        .HasColumnType("int");

                    b.Property<int>("estateId")
                        .HasColumnType("int");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("costId");

                    b.HasIndex("estateId");

                    b.ToTable("costAmounts");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.CostCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("costCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("costCategories");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.CostSubcategory1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("costSubcategory1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("costSubcategories1");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.CostSubcategory2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("costSubcategory2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("costSubcategories2");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.CostType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("costType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("costTypes");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isLocal")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.CropCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("cropCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isMature")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("cropCategories");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.Establishment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("establishment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("establishments");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.Estate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("establishmentId")
                        .HasColumnType("int");

                    b.Property<string>("estateName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("financialYearId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("licenseNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("managerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("membershipTypeId")
                        .HasColumnType("int");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("totalArea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("townId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("companyId");

                    b.HasIndex("establishmentId");

                    b.HasIndex("financialYearId");

                    b.HasIndex("membershipTypeId");

                    b.HasIndex("townId");

                    b.ToTable("estates");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.EstateStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstateId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EstateId");

                    b.ToTable("estateStatusLog");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("area")
                        .HasColumnType("int");

                    b.Property<int>("cropCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateOpenTapping")
                        .HasColumnType("datetime2");

                    b.Property<int>("estateId")
                        .HasColumnType("int");

                    b.Property<string>("fieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isMature")
                        .HasColumnType("bit");

                    b.Property<string>("otherCrop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("totalTask")
                        .HasColumnType("int");

                    b.Property<int>("yearPlanted")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("cropCategoryId");

                    b.HasIndex("estateId");

                    b.ToTable("fields");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.FieldClone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("cloneId")
                        .HasColumnType("int");

                    b.Property<int>("fieldId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("cloneId");

                    b.HasIndex("fieldId");

                    b.ToTable("fieldClones");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.FieldProduction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("cuplump")
                        .HasColumnType("int");

                    b.Property<int>("cuplumpDRC")
                        .HasColumnType("int");

                    b.Property<int>("fieldId")
                        .HasColumnType("int");

                    b.Property<int>("latex")
                        .HasColumnType("int");

                    b.Property<int>("latexDRC")
                        .HasColumnType("int");

                    b.Property<string>("monthYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("noTaskTap")
                        .HasColumnType("int");

                    b.Property<int>("noTaskUntap")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("fieldId");

                    b.ToTable("fieldProductions");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.FinancialYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("financialYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("financialYears");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.Labor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("countryId")
                        .HasColumnType("int");

                    b.Property<int>("estateId")
                        .HasColumnType("int");

                    b.Property<int>("fieldCheckrole")
                        .HasColumnType("int");

                    b.Property<int>("fieldContractor")
                        .HasColumnType("int");

                    b.Property<string>("monthYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tapperCheckrole")
                        .HasColumnType("int");

                    b.Property<int>("tapperContractor")
                        .HasColumnType("int");

                    b.Property<int>("workerNeeded")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("countryId");

                    b.HasIndex("estateId");

                    b.ToTable("labors");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.MembershipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("membershipType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("membershipTypes");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("states");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<int>("stateId")
                        .HasColumnType("int");

                    b.Property<string>("town")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("stateId");

                    b.ToTable("towns");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.UserActivityLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("buttonName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("userActivityLogs");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.Cost", b =>
                {
                    b.HasOne("E_EstateV2_API.Models.CostCategory", "CostCategory")
                        .WithMany()
                        .HasForeignKey("costCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_EstateV2_API.Models.CostSubcategory1", "CostSubcategory1")
                        .WithMany()
                        .HasForeignKey("costSubcategory1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_EstateV2_API.Models.CostSubcategory2", "CostSubcategory2")
                        .WithMany()
                        .HasForeignKey("costSubcategory2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_EstateV2_API.Models.CostType", "CostType")
                        .WithMany()
                        .HasForeignKey("costTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CostCategory");

                    b.Navigation("CostSubcategory1");

                    b.Navigation("CostSubcategory2");

                    b.Navigation("CostType");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.CostAmount", b =>
                {
                    b.HasOne("E_EstateV2_API.Models.Cost", "Cost")
                        .WithMany()
                        .HasForeignKey("costId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_EstateV2_API.Models.Estate", "Estate")
                        .WithMany()
                        .HasForeignKey("estateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cost");

                    b.Navigation("Estate");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.Estate", b =>
                {
                    b.HasOne("E_EstateV2_API.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_EstateV2_API.Models.Establishment", "Establishment")
                        .WithMany()
                        .HasForeignKey("establishmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_EstateV2_API.Models.FinancialYear", "FinancialYear")
                        .WithMany()
                        .HasForeignKey("financialYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_EstateV2_API.Models.MembershipType", "MembershipType")
                        .WithMany()
                        .HasForeignKey("membershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_EstateV2_API.Models.Town", "Town")
                        .WithMany()
                        .HasForeignKey("townId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Establishment");

                    b.Navigation("FinancialYear");

                    b.Navigation("MembershipType");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.EstateStatus", b =>
                {
                    b.HasOne("E_EstateV2_API.Models.Estate", "Estate")
                        .WithMany()
                        .HasForeignKey("EstateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estate");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.Field", b =>
                {
                    b.HasOne("E_EstateV2_API.Models.CropCategory", "CropCategory")
                        .WithMany()
                        .HasForeignKey("cropCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_EstateV2_API.Models.Estate", "Estate")
                        .WithMany()
                        .HasForeignKey("estateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CropCategory");

                    b.Navigation("Estate");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.FieldClone", b =>
                {
                    b.HasOne("E_EstateV2_API.Models.Clone", "Clone")
                        .WithMany()
                        .HasForeignKey("cloneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_EstateV2_API.Models.Field", "Field")
                        .WithMany()
                        .HasForeignKey("fieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clone");

                    b.Navigation("Field");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.FieldProduction", b =>
                {
                    b.HasOne("E_EstateV2_API.Models.Field", "Field")
                        .WithMany()
                        .HasForeignKey("fieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Field");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.Labor", b =>
                {
                    b.HasOne("E_EstateV2_API.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("countryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_EstateV2_API.Models.Estate", "Estate")
                        .WithMany()
                        .HasForeignKey("estateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Estate");
                });

            modelBuilder.Entity("E_EstateV2_API.Models.Town", b =>
                {
                    b.HasOne("E_EstateV2_API.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("stateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });
#pragma warning restore 612, 618
        }
    }
}
