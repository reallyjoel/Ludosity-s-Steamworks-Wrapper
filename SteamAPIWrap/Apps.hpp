#ifndef Apps_h_
#define Apps_h_

#include "Apps.h"

#include "Singleton.hpp"
#include "Services.hpp"
#include "CallbackID.hpp"
#include "ResultID.hpp"

namespace SteamAPIWrap
{
	class CApps : public CSingleton<CApps>
	{
		SW_CALLBACK(CApps, DlcInstalled_t, DlcInstalled);
		SW_CALLBACK(CApps, RegisterActivationCodeResponse_t, RegisterActivationCodeResponse);
		SW_CALLBACK(CApps, AppProofOfPurchaseKeyResponse_t, AppProofOfPurchaseKeyResponse);
		SW_CALLBACK(CApps, NewLaunchQueryParameters_t, NewLaunchQueryParameters);

	public:
		void SetSteamInterface(ISteamApps *apps);
		void RunCallbackSizeCheck();

		bool IsSubscribed();
		bool IsLowViolence();
		bool IsCybercafe();
		bool IsVACBanned();
		PConstantString GetCurrentGameLanguage();
		PConstantString GetAvailableGameLanguages();

		bool IsSubscribedApp( u32 appID );

		bool IsDlcInstalled( u32 appID );

		u32 GetEarliestPurchaseUnixTime( u32 appID );

		bool IsSubscribedFromFreeWeekend();

		int GetDLCCount();

		bool GetDLCDataByIndex( int iDLC, u32 *pAppID, bool *pbAvailable, PString pchName, int cchNameBufferSize );

		void InstallDLC( u32 appID );
		void UninstallDLC( u32 appID );

		void RequestAppProofOfPurchaseKey( u32 appID );

		bool GetCurrentBetaName( PString pchName, int cchNameBufferSize ); // returns current beta branch name, 'public' is the default branch
		bool MarkContentCorrupt( bool bMissingFilesOnly ); // signal Steam that game files seems corrupt or missing
		u32 GetInstalledDepots( u32 appID, u32 *pvecDepots, u32 cMaxDepots ); // return installed depots in mount order
		
		SteamID GetAppOwner(); // returns the SteamID of the original owner. If different from current user, it's borrowed

		PConstantString GetLaunchQueryParam( PConstantString pchKey );
	private:
		friend class CSingleton<CApps>;
		CApps();
		~CApps() {}
		DISALLOW_COPY_AND_ASSIGN(CApps);

		ISteamApps *apps;
	};
};

#endif