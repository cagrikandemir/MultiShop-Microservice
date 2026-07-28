// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"}},
            new ApiResource("ResourceComment"){Scopes={"CommenttFullPermission"}},
            new ApiResource("ResourcePayment"){Scopes={"PaymentFullPermission"}},
            new ApiResource("ResourceImages"){Scopes={"ImagesFullPermission"}},
            new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[] {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full Authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Full Authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full Authority for discount operations"),
            new ApiScope("OrderFullPermission","Full Authority for Order operations"),
            new ApiScope("CargoFullPermission","Full Authority for Cargo operations"),
            new ApiScope("BasketFullPermission","Full Authority for Basket operations"),
            new ApiScope("CommenttFullPermission","Full Authority for Comment operations"),
            new ApiScope("PaymentFullPermission","Full Authority for Payment operations"),
            new ApiScope("ImagesFullPermission","Full Authority for Images operations"),
            new ApiScope("OcelotFullPermission","Full Authority for Ocelot operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //visitor
            new Client
            {
                ClientId="MultiShopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "DiscountFullPermission", "CatalogFullPermission", "CatalogReadPermission", "OcelotFullPermission" , 
                IdentityServerConstants.LocalApi.ScopeName }
            },
            //manager
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission" , "OrderFullPermission" , "CatalogFullPermission", "OcelotFullPermission", "CommenttFullPermission", "PaymentFullPermission", "ImagesFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile }
            },
            //Admin
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission","CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission","CargoFullPermission","BasketFullPermission","CommenttFullPermission" ,"PaymentFullPermission","ImagesFullPermission","OcelotFullPermission" ,
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=600
            }
        };
    }
}