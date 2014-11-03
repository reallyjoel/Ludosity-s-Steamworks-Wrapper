#ifndef Singleton_h_
#define Singleton_h_

namespace SteamAPIWrap
{
	template <class T>
	class CSingleton
	{
	public:
		static T& Instance()
		{
			if (instance == nullptr)
			{
				instance = new T();
			}
			return *instance;
		}
		static void Destroy()
		{
			delete instance;
			instance = nullptr;
		}
	protected:
		CSingleton()
		{
		}
		virtual ~CSingleton()
		{
		}

	private:
		static T *instance;
	};
}

#endif // Singleton_h_