#include "Precompiled.hpp"
#include "Friends.hpp"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CFriends * CSingleton<CFriends>::instance = nullptr;

	CFriends::CFriends()
		: friends(nullptr)
	{

	}

	void CFriends::SetSteamInterface(ISteamFriends *friends)
	{
		this->friends = friends;
	}
}