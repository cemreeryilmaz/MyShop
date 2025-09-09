// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MyShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
           new ApiResource("ResourceCatalog"){Scopes = {"CatalogFullPermission","CatalogReadPermission"}},
           new ApiResource("ResourceDiscount"){Scopes = {"DiscountFullPermission"}},
           new ApiResource("ResourceOrder"){Scopes = {"OrderFullPermission"}},
           new ApiResource("ResourceCargo"){Scopes = {"CargoFullPermission"}},
           new ApiResource("ResourceBasket"){Scopes = {"BasketFullPermission"}},

           new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),

        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope("CargoFullPermission","Full authority for cargo operations"),
            new ApiScope("BasketFullPermission","Full authority for basket operations"),


            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId = "MyShopVisitorId",
                ClientName="My Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("myshopsecret".Sha256())},
                AllowedScopes = { "DiscountFullPermission" }
            },

            //Manager
            new Client
            {
                ClientId = "MyShopManagerId",
                ClientName="My Shop Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("myshopsecret".Sha256())},
                AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission" }
            },

            //Admin
            new Client
            {
                ClientId = "MyShopAdminId",
                ClientName="My Shop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("myshopsecret".Sha256())},
                AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission","CargoFullPermission","BasketFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 600

            }
        };
    }
}