#ifndef Services_h_
#define Services_h_

#include "Services.h"
#include "Singleton.hpp"
#include "ErrorCodes.hpp"
#include "LoadStatus.hpp"

#include "CallbackID.hpp"
#include "ResultID.hpp"

#include <fstream>

namespace SteamAPIWrap
{
	class CServices : public CSteamAPIContext, public CSingleton<CServices>
	{
	public:
		
		bool Startup(u32 interfaceVersion);
		void Shutdown();

		bool IsSteamRunning();

		u32 GetAppID() const { return appID; }
		bool RunCallbackSizeCheck();
		void SetErrorCode(EErrorCodes::Enum error) { errorCode = error; }
		EErrorCodes::Enum GetErrorCode() const { return errorCode; }

		ELoadStatus::Enum GetSteamLoadStatus() const { return steamLoadStatus; }

		void CallManagedCallback(ECallbackID::Enum id, PConstantDataPointer data, s32 dataSize)
		{
			// Ignore the callback if no managed receiver is registered.
			if (managedCallback == nullptr)
			{
				return;
			}

			managedCallback(id, data, dataSize);
		}

		void CallManagedResultCallback(EResultID::Enum id, PConstantDataPointer data, s32 dataSize, bool ioFailure)
		{
			// Ignore the callback if no managed receiver is registered.
			if (managedResultCallback == nullptr)
			{
				return;
			}
			managedResultCallback(id, data, dataSize, ioFailure);
		}

		void RegisterManagedCallbacks(ManagedCallback callback, ManagedResultCallback resultCallback)
		{
			managedCallback = callback;
			managedResultCallback = resultCallback;
		}

		void RemoveManagedCallbacks()
		{
			managedCallback = nullptr;
			managedResultCallback = nullptr;
		}

	private:
		friend class CSingleton<CServices>;
		CServices();
		~CServices() {}
		DISALLOW_COPY_AND_ASSIGN(CServices);
		
		u32 appID;
		EErrorCodes::Enum errorCode;
		ELoadStatus::Enum steamLoadStatus;

		ManagedCallback managedCallback; 
		ManagedResultCallback managedResultCallback;
		
	};
}

#endif // Services_h_