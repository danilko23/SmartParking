// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface ViewController : NSViewController {
	NSTextField *_LoginNameEntry;
	NSTextField *_LoginText;
	NSView *_LoginView;
	NSTextField *_PaswordEntry;
	NSTextField *_WrongEntry;
}

@property (nonatomic, retain) IBOutlet NSTextField *LoginNameEntry;

@property (nonatomic, retain) IBOutlet NSTextField *LoginText;

@property (nonatomic, retain) IBOutlet NSView *LoginView;

@property (nonatomic, retain) IBOutlet NSTextField *PaswordEntry;

@property (nonatomic, retain) IBOutlet NSTextField *WrongEntry;

- (IBAction)OnClickLoginButton:(id)sender;

@end
