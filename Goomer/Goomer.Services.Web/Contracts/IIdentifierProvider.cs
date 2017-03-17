﻿namespace Goomer.Services.Web.Contracts
{
    public interface IIdentifierProvider
    {
        int DecodeId(string urlId);

        string EncodeId(int id);
    }
}
