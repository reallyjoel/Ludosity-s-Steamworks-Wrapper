#ifndef ServicesGameServer_h_
#define ServicesGameServer_h_

#include "ServicesGameServer.h"
#include "Singleton.hpp"
#include "ErrorCodes.hpp"
#include "LoadStatus.hpp"

#include "CallbackID.hpp"
#include "ResultID.hpp"

namespace SteamAPIWrap
{
	class CServicesGameServer : public CSteamGameServerAPIContext, public CSingleton<CServicesGameServer>
	{
	public:
		bool Startup(u32 interfaceVersion, u32 ip, u16 steamPort, u16 gamePort, u16 queryPort, Enum serverMode, PConstantString versionString);
		void Shutdown();

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
		friend class CSingleton<CServicesGameServer>;
		CServicesGameServer();
		~CServicesGameServer() {}
		DISALLOW_COPY_AND_ASSIGN(CServicesGameServer);

		EErrorCodes::Enum errorCode;
		ELoadStatus::Enum steamLoadStatus;

		ManagedCallback managedCallback; 
		ManagedResultCallback managedResultCallback;
	};
}

#endif // ServicesGameServer_h_