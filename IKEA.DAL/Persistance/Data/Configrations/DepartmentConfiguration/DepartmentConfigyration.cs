﻿using IKEA.DAL.Models.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Persistance.Data.Configrations.DepartmentConfiguration
{
    internal class DepartmentConfigyration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {


           builder.Property(D=>D.Id).UseIdentityColumn(10,10);
           builder.Property(D=>D.Name).HasColumnType("varchar(50)").IsRequired();
           builder.Property(D=>D.Code).HasColumnType("varchar(20)").IsRequired();
            //development usage
           builder.Property(D => D.CreadedOn).HasDefaultValueSql("GetDate()");
           builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GetDate()");



           

        }
    }
}
