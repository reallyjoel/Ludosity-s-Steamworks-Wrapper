#ifndef VersionInfo_h_
#define VersionInfo_h_

namespace SteamAPIWrap
{
	class CVersionInfo
	{
	public:
		static u32 GetInterfaceID()
		{
			return interfaceID;
		}

	private:
		DISALLOW_INSTANCE(CVersionInfo);

		static const u32 interfaceID;
	};
}

#endif // VersionInfo_h_