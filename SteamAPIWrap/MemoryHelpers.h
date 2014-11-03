#ifndef MemoryHelpers_h_
#define MemoryHelpers_h_

#include "Types.h"

namespace SteamAPIWrap
{
	/// Converts an array of SteamID's (u64) to an array of CSteamID objects.
	struct SSteamIDArray
	{
	private:
		CSteamID *array;
	public:
		SSteamIDArray(const SteamID *rawIds, s32 idCount)
		{
			array = new CSteamID[idCount];
			for (int i = 0; i < idCount; ++i)
			{
				array[i] = CSteamID(rawIds[i]);
			}
		}

		~SSteamIDArray()
		{
			delete[] array;
		}

		CSteamID * GetArray() const
		{
			return array;
		}

	private:
		DISALLOW_COPY_AND_ASSIGN(SSteamIDArray);
	};
}

#endif // MemoryHelpers_h_
