﻿using System;
using System.Linq;

using ViewModelResolver.Infrastructure;

namespace ViewModelResolver.ViewModels.UsingAnonymousType
{
  public class ListViewModel
  {
    readonly IStore _store;
    readonly IViewModelFactory _factory;

    public ListViewModel(IStore store, IViewModelFactory factory)
    {
      _store = store;
      _factory = factory;

      var customers = _store.LoadAllCustomers();
      foreach (var customer in customers)
      {
        Console.WriteLine("Customer: {0}", customer.Name);
      }
      
      var detailed = customers.First();
      Console.WriteLine("Going to display the details of {0}", detailed.Name);

      _factory.Create<DetailViewModel>(new { customerId = detailed.Id });
    }
  }
}