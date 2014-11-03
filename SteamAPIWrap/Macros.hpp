#ifndef Macros_h_
#define Macros_h_

namespace SteamAPIWrap
{
#define DISALLOW_COPY_AND_ASSIGN(name) \
	name(const name &); \
	name& operator=(const name &)

#define DISALLOW_INSTANCE(name) \
	name(); \
	~name(); \
	DISALLOW_COPY_AND_ASSIGN(name)

#define SW_UNUSED_VARIABLE(x) ((void)(&x));

//#define SW_STATIC_ASSERT(condition) static_assert((condition), #condition)
template <bool Condition> struct SW_StaticAsertFailure;
template <> struct SW_StaticAsertFailure<true> {};


#define SW_UNIQUE_IDENTIFIER2(x, y) x ## y
#define SW_UNIQUE_IDENTIFIER(x, y) SW_UNIQUE_IDENTIFIER2(x, y)
/*
#define SW_STATIC_ASSERT(condition) \
	enum { SW_UNIQUE_IDENTIFIER(staticAssertDummy, __LINE__) = sizeof(SW_StaticAsertFailure< (bool) (condition) > ) }
*/

#define SW_ASYNC_RESULT(className, steamType, resultName) \
private: \
	CCallResult<className, steamType> result##resultName; \
	void On##resultName (steamType *steamData, bool ioFailure) \
	{ \
		CServices::Instance().CallManagedResultCallback(EResultID::resultName, steamData, sizeof(steamType), ioFailure); \
	}

#define SW_GS_ASYNC_RESULT(className, steamType, resultName) \
private: \
	CCallResult<className, steamType> result##resultName; \
	void On##resultName (steamType *steamData, bool ioFailure) \
	{ \
		CServicesGameServer::Instance().CallManagedResultCallback(EResultID::resultName, steamData, sizeof(steamType), ioFailure); \
	}

#if _DEBUG

#define SW_CALLBACK(className, steamType, callbackName) \
private: \
	CCallback<className, steamType, false> native##callbackName##Callback; \
	void On##callbackName (steamType *steamData) \
	{ \
		CServices::Instance().CallManagedCallback(ECallbackID::callbackName, steamData, sizeof(steamType)); \
	}

#else

#define SW_CALLBACK(className, steamType, callbackName) \
private: \
	CCallback<className, steamType, false> native##callbackName##Callback; \
	void On##callbackName (steamType *steamData) \
	{ \
		CServices::Instance().CallManagedCallback(ECallbackID::callbackName, steamData, sizeof(steamType)); \
	}

#endif

#define SW_GS_CALLBACK(className, steamType, callbackName) \
private: \
	CCallback<className, steamType, false> native##callbackName##Callback; \
	void On##callbackName (steamType *steamData) \
	{ \
		CServicesGameServer::Instance().CallManagedCallback(ECallbackID::callbackName, steamData, sizeof(steamType)); \
	}




#define SW_ASYNC_RESULT_CONVERTED(className, steamType, resultName, assignments) \
private: \
	CCallResult<className, steamType> result##resultName; \
	void On##resultName (steamType *steamData, bool ioFailure) \
{ \
	S##resultName converted; \
	assignments \
	CServices::Instance().CallManagedResultCallback(EResultID::resultName, &converted, sizeof(S##resultName), ioFailure); \
}

#define SW_CALLBACK_CONVERTED(className, steamType, callbackName, assignments) \
private: \
	CCallback<className, steamType, false> native##callbackName##Callback; \
	void On##callbackName (steamType *steamData) \
{ \
	S##callbackName converted; \
	assignments \
	CServices::Instance().CallManagedCallback(ECallbackID::callbackName, &converted, sizeof(S##callbackName)); \
}

#define SW_CALLBACK_ASSIGNMENT(customName, steamName)  \
	converted.customName = steamData->steamName
#define SW_CALLBACK_ASSIGNMENT_ENUM(customName, steamName, enumType)  \
	converted.customName = CHelper::ConvertEnum<enumType>(steamData->steamName)
#define SW_CALLBACK_ASSIGNMENT_STEAM_RESULT \
	converted.Result = steamData->m_eResult
#define SW_CALLBACK_ASSIGNMENT_CASTING(customName, steamName, casting)  \
	converted.customName = static_cast< casting >(steamData->steamName)



}

#endif // Macros_h_
