﻿using Bogus;
using NuGet.Frameworks;

namespace rmorais.bug_guzzler.IntegrationTests.Base;

public class BaseFixture
{
    protected Faker Faker { get; set; }

    public BaseFixture() => Faker =new Faker();
}
