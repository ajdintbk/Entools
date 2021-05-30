﻿// <auto-generated />
using System;
using Entools.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entools.Migrations
{
    [DbContext(typeof(EntoolsDbContext))]
    [Migration("20210526082409_versions")]
    partial class versions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entools.Database.Machines", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Entools.Database.Operations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GCodeLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("Entools.Database.Parts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("Entools.Database.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.Property<int>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.HasIndex("VersionId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Entools.Database.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Entools.Database.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Entools.Database.ToolOperations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Operationid")
                        .HasColumnType("int");

                    b.Property<int>("ToolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Operationid");

                    b.HasIndex("ToolId");

                    b.ToTable("ToolOperations");
                });

            modelBuilder.Entity("Entools.Database.Tools", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("Entools.Database.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entools.Database.VersionOperations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.Property<int>("ToolId")
                        .HasColumnType("int");

                    b.Property<int>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.HasIndex("OperationId");

                    b.HasIndex("ToolId");

                    b.HasIndex("VersionId");

                    b.ToTable("VersionOperations");
                });

            modelBuilder.Entity("Entools.Database.VersionRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<int>("ToolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.HasIndex("OperationId");

                    b.HasIndex("RequestId");

                    b.HasIndex("ToolId");

                    b.ToTable("VersionRequests");
                });

            modelBuilder.Entity("Entools.Database.Versions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BottomImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("D10Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D10Sketch3")
                        .HasColumnType("real");

                    b.Property<float>("D11Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D12Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D13Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D14Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D15Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D16Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D17Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D18Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D19Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D1BossExtrude1")
                        .HasColumnType("real");

                    b.Property<float>("D1BossExtrude2")
                        .HasColumnType("real");

                    b.Property<float>("D1CutExtrude1")
                        .HasColumnType("real");

                    b.Property<float>("D1CutExtrude2")
                        .HasColumnType("real");

                    b.Property<float>("D1CutExtrude3")
                        .HasColumnType("real");

                    b.Property<float>("D1Sketch1")
                        .HasColumnType("real");

                    b.Property<float>("D1Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D1Sketch3")
                        .HasColumnType("real");

                    b.Property<float>("D1Sketch5")
                        .HasColumnType("real");

                    b.Property<float>("D20Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D21Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D2Sketch1")
                        .HasColumnType("real");

                    b.Property<float>("D2Sketch3")
                        .HasColumnType("real");

                    b.Property<float>("D2Sketch4")
                        .HasColumnType("real");

                    b.Property<float>("D2Sketch5")
                        .HasColumnType("real");

                    b.Property<float>("D3Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D3Sketch3")
                        .HasColumnType("real");

                    b.Property<float>("D3Sketch4")
                        .HasColumnType("real");

                    b.Property<float>("D3Sketch5")
                        .HasColumnType("real");

                    b.Property<float>("D4Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D4Sketch3")
                        .HasColumnType("real");

                    b.Property<float>("D5Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D5Sketch3")
                        .HasColumnType("real");

                    b.Property<float>("D6Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D6Sketch3")
                        .HasColumnType("real");

                    b.Property<float>("D7Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D7Sketch3")
                        .HasColumnType("real");

                    b.Property<float>("D8Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D8Sketch3")
                        .HasColumnType("real");

                    b.Property<float>("D9Sketch2")
                        .HasColumnType("real");

                    b.Property<float>("D9Sketch3")
                        .HasColumnType("real");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FrontImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GCodePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.ToTable("Versions");
                });

            modelBuilder.Entity("Entools.Database.Request", b =>
                {
                    b.HasOne("Entools.Database.Parts", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entools.Database.Versions", "Version")
                        .WithMany()
                        .HasForeignKey("VersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");

                    b.Navigation("Version");
                });

            modelBuilder.Entity("Entools.Database.ToolOperations", b =>
                {
                    b.HasOne("Entools.Database.Operations", "Operation")
                        .WithMany()
                        .HasForeignKey("Operationid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entools.Database.Tools", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operation");

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("Entools.Database.Users", b =>
                {
                    b.HasOne("Entools.Database.Roles", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Entools.Database.VersionOperations", b =>
                {
                    b.HasOne("Entools.Database.Machines", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entools.Database.Operations", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entools.Database.Tools", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entools.Database.Versions", "Version")
                        .WithMany()
                        .HasForeignKey("VersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");

                    b.Navigation("Operation");

                    b.Navigation("Tool");

                    b.Navigation("Version");
                });

            modelBuilder.Entity("Entools.Database.VersionRequest", b =>
                {
                    b.HasOne("Entools.Database.Machines", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entools.Database.Operations", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entools.Database.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entools.Database.Tools", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");

                    b.Navigation("Operation");

                    b.Navigation("Request");

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("Entools.Database.Versions", b =>
                {
                    b.HasOne("Entools.Database.Parts", "Part")
                        .WithMany("Versions")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");
                });

            modelBuilder.Entity("Entools.Database.Parts", b =>
                {
                    b.Navigation("Versions");
                });
#pragma warning restore 612, 618
        }
    }
}
