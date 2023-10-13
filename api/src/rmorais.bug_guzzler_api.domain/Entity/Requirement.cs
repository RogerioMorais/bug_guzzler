﻿using rmorais.bug_guzzler.domain.SeedWork;
using rmorais.bug_guzzler.domain.Validation;

namespace rmorais.bug_guzzler.domain.Entity;

public class Requirement : AggregateRoot
{
    public Requirement(string description, bool isactive=true)
        :base(){
        Description=description;
        IsActive=isactive;
        CreatedAt=DateTime.Now;
        Validate();
    }

    public string Description { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public void Activate(){
        IsActive=true;
         Validate();
    }

    public void Deactivate(){
        IsActive=false;
         Validate();
    }

    private void Validate()
    {
        DomainValidation.NotNull(Description, nameof(Description));
    }

    public void Update(string? description=null){
      //  this.Description= String.IsNullOrEmpty(description)?this.Description:description;
      this.Description= description??this.Description;
    }
}
