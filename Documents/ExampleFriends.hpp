#ifndef Friends_h_
#define Friends_h_

#include "Friends.h"

#include "Singleton.hpp"
#include "Services.hpp"
#include "CallbackID.hpp"
#include "ResultID.hpp"

namespace SteamAPIWrap
{
	class CFriends : public CSingleton<CFriends>
	{
		// Add callbacks here

	public:
		void SetSteamInterface(ISteamFriends *friends);


	private:
		friend class CSingleton<CFriends>;
		CFriends();
		~CFriends() {}
		DISALLOW_COPY_AND_ASSIGN(CFriends);

		ISteamFriends *friends;
	};
}

#endif // Friends_h_