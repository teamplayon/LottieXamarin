using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Airbnb.Lottie
{
	// @interface LOTAnimationTransitionController : NSObject <UIViewControllerAnimatedTransitioning>
	[BaseType (typeof(NSObject))]
	interface LOTAnimationTransitionController : IUIViewControllerAnimatedTransitioning
	{
		// -(instancetype _Nonnull)initWithAnimationNamed:(NSString * _Nonnull)animation fromLayerNamed:(NSString * _Nullable)fromLayer toLayerNamed:(NSString * _Nullable)toLayer applyAnimationTransform:(BOOL)applyAnimationTransform;
		[Export ("initWithAnimationNamed:fromLayerNamed:toLayerNamed:applyAnimationTransform:")]
		IntPtr Constructor (string animation, [NullAllowed] string fromLayer, [NullAllowed] string toLayer, bool applyAnimationTransform);

		// -(instancetype _Nonnull)initWithAnimationNamed:(NSString * _Nonnull)animation fromLayerNamed:(NSString * _Nullable)fromLayer toLayerNamed:(NSString * _Nullable)toLayer applyAnimationTransform:(BOOL)applyAnimationTransform inBundle:(NSBundle * _Nonnull)bundle;
		[Export ("initWithAnimationNamed:fromLayerNamed:toLayerNamed:applyAnimationTransform:inBundle:")]
		IntPtr Constructor (string animation, [NullAllowed] string fromLayer, [NullAllowed] string toLayer, bool applyAnimationTransform, NSBundle bundle);
	}

	// @interface LOTAnimatedControl : UIControl
	[BaseType (typeof(UIControl))]
	interface LOTAnimatedControl
	{
		// -(void)setLayerName:(NSString * _Nonnull)layerName forState:(UIControlState)state;
		[Export ("setLayerName:forState:")]
		void SetLayerName (string layerName, UIControlState state);

		// @property (readonly, nonatomic, strong) LOTAnimationView * _Nonnull animationView;
		[Export ("animationView", ArgumentSemantic.Strong)]
		LOTAnimationView AnimationView { get; }

		// @property (nonatomic, strong) LOTComposition * _Nullable animationComp;
		[NullAllowed, Export ("animationComp", ArgumentSemantic.Strong)]
		LOTComposition AnimationComp { get; set; }
	}

	// @interface LOTAnimatedSwitch : LOTAnimatedControl
	[BaseType (typeof(LOTAnimatedControl))]
	interface LOTAnimatedSwitch
	{
		// +(instancetype _Nonnull)switchNamed:(NSString * _Nonnull)toggleName;
		[Static]
		[Export ("switchNamed:")]
		LOTAnimatedSwitch SwitchNamed (string toggleName);

		// +(instancetype _Nonnull)switchNamed:(NSString * _Nonnull)toggleName inBundle:(NSBundle * _Nonnull)bundle;
		[Static]
		[Export ("switchNamed:inBundle:")]
		LOTAnimatedSwitch SwitchNamed (string toggleName, NSBundle bundle);

		// @property (getter = isOn, nonatomic) BOOL on;
		[Export ("on")]
		bool On { [Bind ("isOn")] get; set; }

		// @property (nonatomic) BOOL interactiveGesture;
		[Export ("interactiveGesture")]
		bool InteractiveGesture { get; set; }

		// -(void)setOn:(BOOL)on animated:(BOOL)animated;
		[Export ("setOn:animated:")]
		void SetOn (bool on, bool animated);

		// -(void)setProgressRangeForOnState:(CGFloat)fromProgress toProgress:(CGFloat)toProgress __attribute__((swift_name("setProgressRangeForOnState(fromProgress:toProgress:)")));
		[Export ("setProgressRangeForOnState:toProgress:")]
		void SetProgressRangeForOnState (nfloat fromProgress, nfloat toProgress);

		// -(void)setProgressRangeForOffState:(CGFloat)fromProgress toProgress:(CGFloat)toProgress __attribute__((swift_name("setProgressRangeForOffState(fromProgress:toProgress:)")));
		[Export ("setProgressRangeForOffState:toProgress:")]
		void SetProgressRangeForOffState (nfloat fromProgress, nfloat toProgress);
	}

	// @interface LOTCacheProvider : NSObject
	[BaseType (typeof(NSObject))]
	interface LOTCacheProvider
	{
		// +(id<LOTImageCache>)imageCache;
		// +(void)setImageCache:(id<LOTImageCache>)cache;
		[Static]
		[Export ("imageCache")]
		LOTImageCache ImageCache { get; set; }
	}

	// @protocol LOTImageCache <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface LOTImageCache
	{
		// @required -(UIImage *)imageForKey:(NSString *)key;
		[Abstract]
		[Export ("imageForKey:")]
		UIImage ImageForKey (string key);

		// @required -(void)setImage:(UIImage *)image forKey:(NSString *)key;
		[Abstract]
		[Export ("setImage:forKey:")]
		void SetImage (UIImage image, string key);
	}

	// @interface LOTComposition : NSObject
	[BaseType (typeof(NSObject))]
	interface LOTComposition
	{
		// +(instancetype _Nullable)animationNamed:(NSString * _Nonnull)animationName __attribute__((swift_name("init(name:)")));
		[Static]
		[Export ("animationNamed:")]
		[return: NullAllowed]
		LOTComposition AnimationNamed (string animationName);

		// +(instancetype _Nullable)animationNamed:(NSString * _Nonnull)animationName inBundle:(NSBundle * _Nonnull)bundle __attribute__((swift_name("init(name:bundle:)")));
		[Static]
		[Export ("animationNamed:inBundle:")]
		[return: NullAllowed]
		LOTComposition AnimationNamed (string animationName, NSBundle bundle);

		// +(instancetype _Nullable)animationWithFilePath:(NSString * _Nonnull)filePath __attribute__((swift_name("init(filePath:)")));
		[Static]
		[Export ("animationWithFilePath:")]
		[return: NullAllowed]
		LOTComposition AnimationWithFilePath (string filePath);

		// +(instancetype _Nonnull)animationFromJSON:(NSDictionary * _Nonnull)animationJSON __attribute__((swift_name("init(json:)")));
		[Static]
		[Export ("animationFromJSON:")]
		LOTComposition AnimationFromJSON (NSDictionary animationJSON);

		// +(instancetype _Nonnull)animationFromJSON:(NSDictionary * _Nullable)animationJSON inBundle:(NSBundle * _Nullable)bundle __attribute__((swift_name("init(json:bundle:)")));
		[Static]
		[Export ("animationFromJSON:inBundle:")]
		LOTComposition AnimationFromJSON ([NullAllowed] NSDictionary animationJSON, [NullAllowed] NSBundle bundle);

		// -(instancetype _Nonnull)initWithJSON:(NSDictionary * _Nullable)jsonDictionary withAssetBundle:(NSBundle * _Nullable)bundle;
		[Export ("initWithJSON:withAssetBundle:")]
		IntPtr Constructor ([NullAllowed] NSDictionary jsonDictionary, [NullAllowed] NSBundle bundle);

		// @property (readonly, nonatomic) CGRect compBounds;
		[Export ("compBounds")]
		CGRect CompBounds { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable startFrame;
		[NullAllowed, Export ("startFrame", ArgumentSemantic.Strong)]
		NSNumber StartFrame { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable endFrame;
		[NullAllowed, Export ("endFrame", ArgumentSemantic.Strong)]
		NSNumber EndFrame { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable framerate;
		[NullAllowed, Export ("framerate", ArgumentSemantic.Strong)]
		NSNumber Framerate { get; }

		// @property (readonly, nonatomic) NSTimeInterval timeDuration;
		[Export ("timeDuration")]
		double TimeDuration { get; }

		// @property (readonly, nonatomic, strong) LOTLayerGroup * _Nullable layerGroup;
		//[NullAllowed, Export ("layerGroup", ArgumentSemantic.Strong)]
		//LOTLayerGroup LayerGroup { get; }

		// @property (readonly, nonatomic, strong) LOTAssetGroup * _Nullable assetGroup;
		//[NullAllowed, Export ("assetGroup", ArgumentSemantic.Strong)]
		//LOTAssetGroup AssetGroup { get; }

		// @property (readwrite, nonatomic, strong) NSString * _Nullable rootDirectory;
		[NullAllowed, Export ("rootDirectory", ArgumentSemantic.Strong)]
		string RootDirectory { get; set; }

		// @property (readonly, nonatomic, strong) NSBundle * _Nullable assetBundle;
		[NullAllowed, Export ("assetBundle", ArgumentSemantic.Strong)]
		NSBundle AssetBundle { get; }

		// @property (copy, nonatomic) NSString * _Nullable cacheKey;
		[NullAllowed, Export ("cacheKey")]
		string CacheKey { get; set; }
	}

	partial interface Constants
	{
		// extern NSString *const _Nonnull kLOTKeypathEnd;
		[Field ("kLOTKeypathEnd", "__Internal")]
		NSString kLOTKeypathEnd { get; }
	}

	// @interface LOTKeypath : NSObject
	[BaseType (typeof(NSObject))]
	interface LOTKeypath
	{
		// +(LOTKeypath * _Nonnull)keypathWithString:(NSString * _Nonnull)keypath;
		[Static]
		[Export ("keypathWithString:")]
		LOTKeypath KeypathWithString (string keypath);

		// +(LOTKeypath * _Nonnull)keypathWithKeys:(NSString * _Nonnull)firstKey, ... __attribute__((sentinel(0, 1)));
		[Static, Internal]
		[Export ("keypathWithKeys:", IsVariadic = true)]
		LOTKeypath KeypathWithKeys (string firstKey, IntPtr varArgs);

		// @property (readonly, nonatomic) NSString * _Nonnull absoluteKeypath;
		[Export ("absoluteKeypath")]
		string AbsoluteKeypath { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull currentKey;
		[Export ("currentKey")]
		string CurrentKey { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull currentKeyPath;
		[Export ("currentKeyPath")]
		string CurrentKeyPath { get; }

		// @property (readonly, nonatomic) NSDictionary * _Nonnull searchResults;
		[Export ("searchResults")]
		NSDictionary SearchResults { get; }

		// @property (readonly, nonatomic) BOOL hasFuzzyWildcard;
		[Export ("hasFuzzyWildcard")]
		bool HasFuzzyWildcard { get; }

		// @property (readonly, nonatomic) BOOL hasWildcard;
		[Export ("hasWildcard")]
		bool HasWildcard { get; }

		// @property (readonly, nonatomic) BOOL endOfKeypath;
		[Export ("endOfKeypath")]
		bool EndOfKeypath { get; }

		// -(BOOL)pushKey:(NSString * _Nonnull)key;
		[Export ("pushKey:")]
		bool PushKey (string key);

		// -(void)popKey;
		[Export ("popKey")]
		void PopKey ();

		// -(void)popToRootKey;
		[Export ("popToRootKey")]
		void PopToRootKey ();

		// -(void)addSearchResultForCurrentPath:(id _Nonnull)result;
		[Export ("addSearchResultForCurrentPath:")]
		void AddSearchResultForCurrentPath (NSObject result);
	}

	// @protocol LOTValueDelegate <NSObject>
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	[BaseType (typeof(NSObject))]
	interface LOTValueDelegate
	{
	}

	// @protocol LOTColorValueDelegate <LOTValueDelegate>
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	interface LOTColorValueDelegate : LOTValueDelegate
	{
		// @required -(CGColorRef)colorForFrame:(CGFloat)currentFrame startKeyframe:(CGFloat)startKeyframe endKeyframe:(CGFloat)endKeyframe interpolatedProgress:(CGFloat)interpolatedProgress startColor:(CGColorRef)startColor endColor:(CGColorRef)endColor currentColor:(CGColorRef)interpolatedColor;
		[Abstract]
		[Export ("colorForFrame:startKeyframe:endKeyframe:interpolatedProgress:startColor:endColor:currentColor:")]
		CGColor StartKeyframe (nfloat currentFrame, nfloat startKeyframe, nfloat endKeyframe, nfloat interpolatedProgress, CGColor startColor, CGColor endColor, CGColor interpolatedColor);
	}

	// @protocol LOTNumberValueDelegate <LOTValueDelegate>
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	interface LOTNumberValueDelegate : LOTValueDelegate
	{
		// @required -(CGFloat)floatValueForFrame:(CGFloat)currentFrame startKeyframe:(CGFloat)startKeyframe endKeyframe:(CGFloat)endKeyframe interpolatedProgress:(CGFloat)interpolatedProgress startValue:(CGFloat)startValue endValue:(CGFloat)endValue currentValue:(CGFloat)interpolatedValue;
		[Abstract]
		[Export ("floatValueForFrame:startKeyframe:endKeyframe:interpolatedProgress:startValue:endValue:currentValue:")]
		nfloat StartKeyframe (nfloat currentFrame, nfloat startKeyframe, nfloat endKeyframe, nfloat interpolatedProgress, nfloat startValue, nfloat endValue, nfloat interpolatedValue);
	}

	// @protocol LOTPointValueDelegate <LOTValueDelegate>
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	interface LOTPointValueDelegate : LOTValueDelegate
	{
		// @required -(CGPoint)pointForFrame:(CGFloat)currentFrame startKeyframe:(CGFloat)startKeyframe endKeyframe:(CGFloat)endKeyframe interpolatedProgress:(CGFloat)interpolatedProgress startPoint:(CGPoint)startPoint endPoint:(CGPoint)endPoint currentPoint:(CGPoint)interpolatedPoint;
		[Abstract]
		[Export ("pointForFrame:startKeyframe:endKeyframe:interpolatedProgress:startPoint:endPoint:currentPoint:")]
		CGPoint StartKeyframe (nfloat currentFrame, nfloat startKeyframe, nfloat endKeyframe, nfloat interpolatedProgress, CGPoint startPoint, CGPoint endPoint, CGPoint interpolatedPoint);
	}

	// @protocol LOTSizeValueDelegate <LOTValueDelegate>
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	interface LOTSizeValueDelegate : LOTValueDelegate
	{
		// @required -(CGSize)sizeForFrame:(CGFloat)currentFrame startKeyframe:(CGFloat)startKeyframe endKeyframe:(CGFloat)endKeyframe interpolatedProgress:(CGFloat)interpolatedProgress startSize:(CGSize)startSize endSize:(CGSize)endSize currentSize:(CGSize)interpolatedSize;
		[Abstract]
		[Export ("sizeForFrame:startKeyframe:endKeyframe:interpolatedProgress:startSize:endSize:currentSize:")]
		CGSize StartKeyframe (nfloat currentFrame, nfloat startKeyframe, nfloat endKeyframe, nfloat interpolatedProgress, CGSize startSize, CGSize endSize, CGSize interpolatedSize);
	}

	// @protocol LOTPathValueDelegate <LOTValueDelegate>
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	interface LOTPathValueDelegate : LOTValueDelegate
	{
		// @required -(CGPathRef)pathForFrame:(CGFloat)currentFrame startKeyframe:(CGFloat)startKeyframe endKeyframe:(CGFloat)endKeyframe interpolatedProgress:(CGFloat)interpolatedProgress;
		[Abstract]
		[Export ("pathForFrame:startKeyframe:endKeyframe:interpolatedProgress:")]
		CGPath StartKeyframe (nfloat currentFrame, nfloat startKeyframe, nfloat endKeyframe, nfloat interpolatedProgress);
	}

	// typedef void (^LOTAnimationCompletionBlock)(BOOL);
	delegate void LOTAnimationCompletionBlock (bool animationFinished);

	// @interface LOTAnimationView : UIView
	[BaseType (typeof(UIView))]
	interface LOTAnimationView
	{
		// +(instancetype _Nonnull)animationNamed:(NSString * _Nonnull)animationName __attribute__((swift_name("init(name:)")));
		[Static]
		[Export ("animationNamed:")]
		LOTAnimationView AnimationNamed (string animationName);

		// +(instancetype _Nonnull)animationNamed:(NSString * _Nonnull)animationName inBundle:(NSBundle * _Nonnull)bundle __attribute__((swift_name("init(name:bundle:)")));
		[Static]
		[Export ("animationNamed:inBundle:")]
		LOTAnimationView AnimationNamed (string animationName, NSBundle bundle);

		// +(instancetype _Nonnull)animationFromJSON:(NSDictionary * _Nonnull)animationJSON __attribute__((swift_name("init(json:)")));
		[Static]
		[Export ("animationFromJSON:")]
		LOTAnimationView AnimationFromJSON (NSDictionary animationJSON);

		// +(instancetype _Nonnull)animationWithFilePath:(NSString * _Nonnull)filePath __attribute__((swift_name("init(filePath:)")));
		[Static]
		[Export ("animationWithFilePath:")]
		LOTAnimationView AnimationWithFilePath (string filePath);

		// +(instancetype _Nonnull)animationFromJSON:(NSDictionary * _Nullable)animationJSON inBundle:(NSBundle * _Nullable)bundle __attribute__((swift_name("init(json:bundle:)")));
		[Static]
		[Export ("animationFromJSON:inBundle:")]
		LOTAnimationView AnimationFromJSON ([NullAllowed] NSDictionary animationJSON, [NullAllowed] NSBundle bundle);

		// -(instancetype _Nonnull)initWithModel:(LOTComposition * _Nullable)model inBundle:(NSBundle * _Nullable)bundle;
		[Export ("initWithModel:inBundle:")]
		IntPtr Constructor ([NullAllowed] LOTComposition model, [NullAllowed] NSBundle bundle);

		// -(instancetype _Nonnull)initWithContentsOfURL:(NSURL * _Nonnull)url;
		[Export ("initWithContentsOfURL:")]
		IntPtr Constructor (NSUrl url);

		// @property (nonatomic, strong) NSString * _Nullable animation;
		[NullAllowed, Export ("animation", ArgumentSemantic.Strong)]
		string Animation { get; set; }

		// -(void)setAnimationNamed:(NSString * _Nonnull)animationName __attribute__((swift_name("setAnimation(named:)")));
		[Export ("setAnimationNamed:")]
		void SetAnimationNamed (string animationName);

		// -(void)setAnimationNamed:(NSString * _Nonnull)animationName inBundle:(NSBundle * _Nullable)bundle __attribute__((swift_name("setAnimation(named:bundle:)")));
		[Export ("setAnimationNamed:inBundle:")]
		void SetAnimationNamed (string animationName, [NullAllowed] NSBundle bundle);

		// -(void)setAnimationFromJSON:(NSDictionary * _Nonnull)animationJSON __attribute__((swift_name("setAnimation(json:)")));
		[Export ("setAnimationFromJSON:")]
		void SetAnimationFromJSON (NSDictionary animationJSON);

		// -(void)setAnimationFromJSON:(NSDictionary * _Nonnull)animationJSON inBundle:(NSBundle * _Nullable)bundle __attribute__((swift_name("setAnimation(json:bundle:)")));
		[Export ("setAnimationFromJSON:inBundle:")]
		void SetAnimationFromJSON (NSDictionary animationJSON, [NullAllowed] NSBundle bundle);

		// @property (readonly, nonatomic) BOOL isAnimationPlaying;
		[Export ("isAnimationPlaying")]
		bool IsAnimationPlaying { get; }

		// @property (assign, nonatomic) BOOL loopAnimation;
		[Export ("loopAnimation")]
		bool LoopAnimation { get; set; }

		// @property (assign, nonatomic) BOOL autoReverseAnimation;
		[Export ("autoReverseAnimation")]
		bool AutoReverseAnimation { get; set; }

		// @property (assign, nonatomic) CGFloat animationProgress;
		[Export ("animationProgress")]
		nfloat AnimationProgress { get; set; }

		// @property (assign, nonatomic) CGFloat animationSpeed;
		[Export ("animationSpeed")]
		nfloat AnimationSpeed { get; set; }

		// @property (readonly, nonatomic) CGFloat animationDuration;
		[Export ("animationDuration")]
		nfloat AnimationDuration { get; }

		// @property (assign, nonatomic) BOOL cacheEnable;
		[Export ("cacheEnable")]
		bool CacheEnable { get; set; }

		// @property (copy, nonatomic) LOTAnimationCompletionBlock _Nullable completionBlock;
		[NullAllowed, Export ("completionBlock", ArgumentSemantic.Copy)]
		LOTAnimationCompletionBlock CompletionBlock { get; set; }

		// @property (nonatomic, strong) LOTComposition * _Nullable sceneModel;
		[NullAllowed, Export ("sceneModel", ArgumentSemantic.Strong)]
		LOTComposition SceneModel { get; set; }

		// @property (assign, nonatomic) BOOL shouldRasterizeWhenIdle;
		[Export ("shouldRasterizeWhenIdle")]
		bool ShouldRasterizeWhenIdle { get; set; }

		// -(void)playToProgress:(CGFloat)toProgress withCompletion:(LOTAnimationCompletionBlock _Nullable)completion;
		[Export ("playToProgress:withCompletion:")]
		void PlayToProgress (nfloat toProgress, [NullAllowed] LOTAnimationCompletionBlock completion);

		// -(void)playFromProgress:(CGFloat)fromStartProgress toProgress:(CGFloat)toEndProgress withCompletion:(LOTAnimationCompletionBlock _Nullable)completion;
		[Export ("playFromProgress:toProgress:withCompletion:")]
		void PlayFromProgress (nfloat fromStartProgress, nfloat toEndProgress, [NullAllowed] LOTAnimationCompletionBlock completion);

		// -(void)playToFrame:(NSNumber * _Nonnull)toFrame withCompletion:(LOTAnimationCompletionBlock _Nullable)completion;
		[Export ("playToFrame:withCompletion:")]
		void PlayToFrame (NSNumber toFrame, [NullAllowed] LOTAnimationCompletionBlock completion);

		// -(void)playFromFrame:(NSNumber * _Nonnull)fromStartFrame toFrame:(NSNumber * _Nonnull)toEndFrame withCompletion:(LOTAnimationCompletionBlock _Nullable)completion;
		[Export ("playFromFrame:toFrame:withCompletion:")]
		void PlayFromFrame (NSNumber fromStartFrame, NSNumber toEndFrame, [NullAllowed] LOTAnimationCompletionBlock completion);

		// -(void)playWithCompletion:(LOTAnimationCompletionBlock _Nullable)completion;
		[Export ("playWithCompletion:")]
		void PlayWithCompletion ([NullAllowed] LOTAnimationCompletionBlock completion);

		// -(void)play;
		[Export ("play")]
		void Play ();

		// -(void)pause;
		[Export ("pause")]
		void Pause ();

		// -(void)stop;
		[Export ("stop")]
		void Stop ();

		// -(void)setProgressWithFrame:(NSNumber * _Nonnull)currentFrame;
		[Export ("setProgressWithFrame:")]
		void SetProgressWithFrame (NSNumber currentFrame);

		// -(void)forceDrawingUpdate;
		[Export ("forceDrawingUpdate")]
		void ForceDrawingUpdate ();

		// -(void)logHierarchyKeypaths;
		[Export ("logHierarchyKeypaths")]
		void LogHierarchyKeypaths ();

		// -(void)setValueDelegate:(id<LOTValueDelegate> _Nonnull)delegates forKeypath:(LOTKeypath * _Nonnull)keypath;
		[Export ("setValueDelegate:forKeypath:")]
		void SetValueDelegate (LOTValueDelegate delegates, LOTKeypath keypath);

		// -(NSArray * _Nullable)keysForKeyPath:(LOTKeypath * _Nonnull)keypath;
		[Export ("keysForKeyPath:")]
		[return: NullAllowed]
		NSObject[] KeysForKeyPath (LOTKeypath keypath);

		// -(CGPoint)convertPoint:(CGPoint)point toKeypathLayer:(LOTKeypath * _Nonnull)keypath;
		[Export ("convertPoint:toKeypathLayer:")]
		CGPoint ConvertPointToKeypath (CGPoint point, LOTKeypath keypath);

		// -(CGRect)convertRect:(CGRect)rect toKeypathLayer:(LOTKeypath * _Nonnull)keypath;
		[Export ("convertRect:toKeypathLayer:")]
		CGRect ConvertRectToKeypath (CGRect rect, LOTKeypath keypath);

		// -(CGPoint)convertPoint:(CGPoint)point fromKeypathLayer:(LOTKeypath * _Nonnull)keypath;
		[Export ("convertPoint:fromKeypathLayer:")]
		CGPoint ConvertPointFromKeypath (CGPoint point, LOTKeypath keypath);

		// -(CGRect)convertRect:(CGRect)rect fromKeypathLayer:(LOTKeypath * _Nonnull)keypath;
		[Export ("convertRect:fromKeypathLayer:")]
		CGRect ConvertRectFromKeypath (CGRect rect, LOTKeypath keypath);

		// -(void)addSubview:(UIView * _Nonnull)view toKeypathLayer:(LOTKeypath * _Nonnull)keypath;
		[Export ("addSubview:toKeypathLayer:")]
		void AddSubview (UIView view, LOTKeypath keypath);

		// -(void)maskSubview:(UIView * _Nonnull)view toKeypathLayer:(LOTKeypath * _Nonnull)keypath;
		[Export ("maskSubview:toKeypathLayer:")]
		void MaskSubview (UIView view, LOTKeypath keypath);

		// -(void)setValue:(id _Nonnull)value forKeypath:(NSString * _Nonnull)keypath atFrame:(NSNumber * _Nullable)frame __attribute__((deprecated("")));
		[Export ("setValue:forKeypath:atFrame:")]
		void SetValue (NSObject value, string keypath, [NullAllowed] NSNumber frame);

		// -(void)addSubview:(UIView * _Nonnull)view toLayerNamed:(NSString * _Nonnull)layer applyTransform:(BOOL)applyTransform __attribute__((deprecated("")));
		[Export ("addSubview:toLayerNamed:applyTransform:")]
		void AddSubview (UIView view, string layer, bool applyTransform);

		// -(CGRect)convertRect:(CGRect)rect toLayerNamed:(NSString * _Nullable)layerName __attribute__((deprecated("")));
		[Export ("convertRect:toLayerNamed:")]
		CGRect ConvertRect (CGRect rect, [NullAllowed] string layerName);
	}

	// @interface LOTAnimationCache : NSObject
	[BaseType (typeof(NSObject))]
	interface LOTAnimationCache
	{
		// +(instancetype _Nonnull)sharedCache;
		[Static]
		[Export ("sharedCache")]
		LOTAnimationCache SharedCache ();

		// -(void)addAnimation:(LOTComposition * _Nonnull)animation forKey:(NSString * _Nonnull)key;
		[Export ("addAnimation:forKey:")]
		void AddAnimation (LOTComposition animation, string key);

		// -(LOTComposition * _Nullable)animationForKey:(NSString * _Nonnull)key;
		[Export ("animationForKey:")]
		[return: NullAllowed]
		LOTComposition AnimationForKey (string key);

		// -(void)removeAnimationForKey:(NSString * _Nonnull)key;
		[Export ("removeAnimationForKey:")]
		void RemoveAnimationForKey (string key);

		// -(void)clearCache;
		[Export ("clearCache")]
		void ClearCache ();

		// -(void)disableCaching;
		[Export ("disableCaching")]
		void DisableCaching ();
	}

	// typedef CGColorRef _Nonnull (^LOTColorValueCallbackBlock)(CGFloat, CGFloat, CGFloat, CGFloat, CGColorRef _Nullable, CGColorRef _Nullable, CGColorRef _Nullable);
	delegate IntPtr LOTColorValueCallbackBlock (nfloat currentFrame, nfloat startKeyFrame, nfloat endKeyFrame, nfloat interpolatedProgress, [NullAllowed] IntPtr startColor, [NullAllowed] IntPtr endColor, [NullAllowed] IntPtr interpolatedColor);

	// typedef CGFloat (^LOTNumberValueCallbackBlock)(CGFloat, CGFloat, CGFloat, CGFloat, CGFloat, CGFloat, CGFloat);
	delegate nfloat LOTNumberValueCallbackBlock (nfloat currentFrame, nfloat startKeyFrame, nfloat endKeyFrame, nfloat interpolatedProgress, nfloat startValue, nfloat endValue, nfloat interpolatedValue);

	// typedef CGPoint (^LOTPointValueCallbackBlock)(CGFloat, CGFloat, CGFloat, CGFloat, CGPoint, CGPoint, CGPoint);
	delegate CGPoint LOTPointValueCallbackBlock (nfloat currentFrame, nfloat startKeyFrame, nfloat endKeyFrame, nfloat interpolatedProgress, CGPoint startPoint, CGPoint endPoint, CGPoint interpolatedPoint);

	// typedef CGSize (^LOTSizeValueCallbackBlock)(CGFloat, CGFloat, CGFloat, CGFloat, CGSize, CGSize, CGSize);
	delegate CGSize LOTSizeValueCallbackBlock (nfloat currentFrame, nfloat startKeyFrame, nfloat endKeyFrame, nfloat interpolatedProgress, CGSize startSize, CGSize endSize, CGSize interpolatedSize);

	// typedef CGPathRef _Nonnull (^LOTPathValueCallbackBlock)(CGFloat, CGFloat, CGFloat, CGFloat);
	delegate CGPath LOTPathValueCallbackBlock (nfloat currentFrame, nfloat startKeyFrame, nfloat endKeyFrame, nfloat interpolatedProgress);

	// @interface LOTColorBlockCallback : NSObject <LOTColorValueDelegate>
	[BaseType (typeof(NSObject))]
	interface LOTColorBlockCallback : ILOTColorValueDelegate
	{
		// +(instancetype _Nonnull)withBlock:(LOTColorValueCallbackBlock _Nonnull)block __attribute__((swift_name("init(block:)")));
		[Static]
		[Export ("withBlock:")]
		LOTColorBlockCallback WithBlock (LOTColorValueCallbackBlock block);

		// @property (copy, nonatomic) LOTColorValueCallbackBlock _Nonnull callback;
		[Export ("callback", ArgumentSemantic.Copy)]
		LOTColorValueCallbackBlock Callback { get; set; }
	}

	// @interface LOTNumberBlockCallback : NSObject <LOTNumberValueDelegate>
	[BaseType (typeof(NSObject))]
	interface LOTNumberBlockCallback : ILOTNumberValueDelegate
	{
		// +(instancetype _Nonnull)withBlock:(LOTNumberValueCallbackBlock _Nonnull)block __attribute__((swift_name("init(block:)")));
		[Static]
		[Export ("withBlock:")]
		LOTNumberBlockCallback WithBlock (LOTNumberValueCallbackBlock block);

		// @property (copy, nonatomic) LOTNumberValueCallbackBlock _Nonnull callback;
		[Export ("callback", ArgumentSemantic.Copy)]
		LOTNumberValueCallbackBlock Callback { get; set; }
	}

	// @interface LOTPointBlockCallback : NSObject <LOTPointValueDelegate>
	[BaseType (typeof(NSObject))]
	interface LOTPointBlockCallback : ILOTPointValueDelegate
	{
		// +(instancetype _Nonnull)withBlock:(LOTPointValueCallbackBlock _Nonnull)block __attribute__((swift_name("init(block:)")));
		[Static]
		[Export ("withBlock:")]
		LOTPointBlockCallback WithBlock (LOTPointValueCallbackBlock block);

		// @property (copy, nonatomic) LOTPointValueCallbackBlock _Nonnull callback;
		[Export ("callback", ArgumentSemantic.Copy)]
		LOTPointValueCallbackBlock Callback { get; set; }
	}

	// @interface LOTSizeBlockCallback : NSObject <LOTSizeValueDelegate>
	[BaseType (typeof(NSObject))]
	interface LOTSizeBlockCallback : ILOTSizeValueDelegate
	{
		// +(instancetype _Nonnull)withBlock:(LOTSizeValueCallbackBlock _Nonnull)block __attribute__((swift_name("init(block:)")));
		[Static]
		[Export ("withBlock:")]
		LOTSizeBlockCallback WithBlock (LOTSizeValueCallbackBlock block);

		// @property (copy, nonatomic) LOTSizeValueCallbackBlock _Nonnull callback;
		[Export ("callback", ArgumentSemantic.Copy)]
		LOTSizeValueCallbackBlock Callback { get; set; }
	}

	// @interface LOTPathBlockCallback : NSObject <LOTPathValueDelegate>
	[BaseType (typeof(NSObject))]
	interface LOTPathBlockCallback : ILOTPathValueDelegate
	{
		// +(instancetype _Nonnull)withBlock:(LOTPathValueCallbackBlock _Nonnull)block __attribute__((swift_name("init(block:)")));
		[Static]
		[Export ("withBlock:")]
		LOTPathBlockCallback WithBlock (LOTPathValueCallbackBlock block);

		// @property (copy, nonatomic) LOTPathValueCallbackBlock _Nonnull callback;
		[Export ("callback", ArgumentSemantic.Copy)]
		LOTPathValueCallbackBlock Callback { get; set; }
	}

	// @interface LOTPointInterpolatorCallback : NSObject <LOTPointValueDelegate>
	[BaseType (typeof(NSObject))]
	interface LOTPointInterpolatorCallback : ILOTPointValueDelegate
	{
		// +(instancetype _Nonnull)withFromPoint:(CGPoint)fromPoint toPoint:(CGPoint)toPoint __attribute__((swift_name("init(from:to:)")));
		[Static]
		[Export ("withFromPoint:toPoint:")]
		LOTPointInterpolatorCallback WithFromPoint (CGPoint fromPoint, CGPoint toPoint);

		// @property (nonatomic) CGPoint fromPoint;
		[Export ("fromPoint", ArgumentSemantic.Assign)]
		CGPoint FromPoint { get; set; }

		// @property (nonatomic) CGPoint toPoint;
		[Export ("toPoint", ArgumentSemantic.Assign)]
		CGPoint ToPoint { get; set; }

		// @property (assign, nonatomic) CGFloat currentProgress;
		[Export ("currentProgress")]
		nfloat CurrentProgress { get; set; }
	}

	// @interface LOTSizeInterpolatorCallback : NSObject <LOTSizeValueDelegate>
	[BaseType (typeof(NSObject))]
	interface LOTSizeInterpolatorCallback : ILOTSizeValueDelegate
	{
		// +(instancetype _Nonnull)withFromSize:(CGSize)fromSize toSize:(CGSize)toSize __attribute__((swift_name("init(from:to:)")));
		[Static]
		[Export ("withFromSize:toSize:")]
		LOTSizeInterpolatorCallback WithFromSize (CGSize fromSize, CGSize toSize);

		// @property (nonatomic) CGSize fromSize;
		[Export ("fromSize", ArgumentSemantic.Assign)]
		CGSize FromSize { get; set; }

		// @property (nonatomic) CGSize toSize;
		[Export ("toSize", ArgumentSemantic.Assign)]
		CGSize ToSize { get; set; }

		// @property (assign, nonatomic) CGFloat currentProgress;
		[Export ("currentProgress")]
		nfloat CurrentProgress { get; set; }
	}

	// @interface LOTFloatInterpolatorCallback : NSObject <LOTNumberValueDelegate>
	[BaseType (typeof(NSObject))]
	interface LOTFloatInterpolatorCallback : ILOTNumberValueDelegate
	{
		// +(instancetype _Nonnull)withFromFloat:(CGFloat)fromFloat toFloat:(CGFloat)toFloat __attribute__((swift_name("init(from:to:)")));
		[Static]
		[Export ("withFromFloat:toFloat:")]
		LOTFloatInterpolatorCallback WithFromFloat (nfloat fromFloat, nfloat toFloat);

		// @property (nonatomic) CGFloat fromFloat;
		[Export ("fromFloat")]
		nfloat FromFloat { get; set; }

		// @property (nonatomic) CGFloat toFloat;
		[Export ("toFloat")]
		nfloat ToFloat { get; set; }

		// @property (assign, nonatomic) CGFloat currentProgress;
		[Export ("currentProgress")]
		nfloat CurrentProgress { get; set; }
	}

	// @interface LOTColorValueCallback : NSObject <LOTColorValueDelegate>
	[BaseType (typeof(NSObject))]
	interface LOTColorValueCallback : ILOTColorValueDelegate
	{
		// +(instancetype _Nonnull)withCGColor:(CGColorRef _Nonnull)color __attribute__((swift_name("init(color:)")));
		[Static]
		[Export ("withCGColor:")]
		LOTColorValueCallback WithCGColor (CGColor color);

		// @property (nonatomic) CGColorRef _Nonnull colorValue;
		[Export ("colorValue", ArgumentSemantic.Assign)]
		CGColor ColorValue { get; set; }
	}

	// @interface LOTNumberValueCallback : NSObject <LOTNumberValueDelegate>
	[BaseType (typeof(NSObject))]
	interface LOTNumberValueCallback : ILOTNumberValueDelegate
	{
		// +(instancetype _Nonnull)withFloatValue:(CGFloat)numberValue __attribute__((swift_name("init(number:)")));
		[Static]
		[Export ("withFloatValue:")]
		LOTNumberValueCallback WithFloatValue (nfloat numberValue);

		// @property (assign, nonatomic) CGFloat numberValue;
		[Export ("numberValue")]
		nfloat NumberValue { get; set; }
	}

	// @interface LOTPointValueCallback : NSObject <LOTPointValueDelegate>
	[BaseType (typeof(NSObject))]
	interface LOTPointValueCallback : ILOTPointValueDelegate
	{
		// +(instancetype _Nonnull)withPointValue:(CGPoint)pointValue;
		[Static]
		[Export ("withPointValue:")]
		LOTPointValueCallback WithPointValue (CGPoint pointValue);

		// @property (assign, nonatomic) CGPoint pointValue;
		[Export ("pointValue", ArgumentSemantic.Assign)]
		CGPoint PointValue { get; set; }
	}

	// @interface LOTSizeValueCallback : NSObject <LOTSizeValueDelegate>
	[BaseType (typeof(NSObject))]
	interface LOTSizeValueCallback : ILOTSizeValueDelegate
	{
		// +(instancetype _Nonnull)withPointValue:(CGSize)sizeValue __attribute__((swift_name("init(size:)")));
		[Static]
		[Export ("withPointValue:")]
		LOTSizeValueCallback WithPointValue (CGSize sizeValue);

		// @property (assign, nonatomic) CGSize sizeValue;
		[Export ("sizeValue", ArgumentSemantic.Assign)]
		CGSize SizeValue { get; set; }
	}

	// @interface LOTPathValueCallback : NSObject <LOTPathValueDelegate>
	[BaseType (typeof(NSObject))]
	interface LOTPathValueCallback : ILOTPathValueDelegate
	{
		// +(instancetype _Nonnull)withCGPath:(CGPathRef _Nonnull)path __attribute__((swift_name("init(path:)")));
		[Static]
		[Export ("withCGPath:")]
		LOTPathValueCallback WithCGPath (CGPath path);

		// @property (nonatomic) CGPathRef _Nonnull pathValue;
		[Export ("pathValue", ArgumentSemantic.Assign)]
		CGPath PathValue { get; set; }
	}
}
