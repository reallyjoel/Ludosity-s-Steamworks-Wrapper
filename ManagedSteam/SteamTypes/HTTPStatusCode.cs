using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    public enum HTTPStatusCode
    {
        Invalid = 0,

        // Informational codes
        Code100Continue = 100,
        Code101SwitchingProtocols = 101,

        // Success codes
        Code200OK = 200,
        Code201Created = 201,
        Code202Accepted = 202,
        Code203NonAuthoritative = 203,
        Code204NoContent = 204,
        Code205ResetContent = 205,
        Code206PartialContent = 206,

        // Redirection codes
        Code300MultipleChoices = 300,
        Code301MovedPermanently = 301,
        Code302Found = 302,
        Code303SeeOther = 303,
        Code304NotModified = 304,
        Code305UseProxy = 305,
        //k_EHTTPStatusCode306Unused =				306, (used in old HTTP spec, now unused in 1.1)
        Code307TemporaryRedirect = 307,

        // Error codes
        Code400BadRequest = 400,
        Code401Unauthorized = 401,
        Code402PaymentRequired = 402, // This is reserved for future HTTP specs, not really supported by clients
        Code403Forbidden = 403,
        Code404NotFound = 404,
        Code405MethodNotAllowed = 405,
        Code406NotAcceptable = 406,
        Code407ProxyAuthRequired = 407,
        Code408RequestTimeout = 408,
        Code409Conflict = 409,
        Code410Gone = 410,
        Code411LengthRequired = 411,
        Code412PreconditionFailed = 412,
        Code413RequestEntityTooLarge = 413,
        Code414RequestURITooLong = 414,
        Code415UnsupportedMediaType = 415,
        Code416RequestedRangeNotSatisfiable = 416,
        Code417ExpectationFailed = 417,

        // Server error codes
        Code500InternalServerError = 500,
        Code501NotImplemented = 501,
        Code502BadGateway = 502,
        Code503ServiceUnavailable = 503,
        Code504GatewayTimeout = 504,
        Code505HTTPVersionNotSupported = 505,
    }
}
