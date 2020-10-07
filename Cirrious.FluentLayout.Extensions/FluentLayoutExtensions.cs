using System;
using Cirrious.FluentLayouts.Touch;
using UIKit;

namespace Cirrious.FluentLayout.Extensions
{
    public static class FluentLayoutExtensions
    {
        const float DefaultMargin = 0;
        const float DefaultScale = 1;

        public static FluentLayouts.Touch.FluentLayout AtTopOfLayoutGuide(this UIView view, UILayoutGuide layoutGuide, nfloat? margin = null) =>
            view.Top().EqualTo().TopOf(layoutGuide).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayouts.Touch.FluentLayout AtTopOfMargins(this UIView view, UIView parentView, nfloat? margin = null) =>
            UIDevice.CurrentDevice.CheckSystemVersion(9, 0)
                ? view.AtTopOfLayoutGuide(parentView.LayoutMarginsGuide, margin)
                : view.AtTopOf(parentView, margin);

        public static FluentLayouts.Touch.FluentLayout AtTopOfReadableContent(this UIView view, UIView parentView, nfloat? margin = null) =>
            UIDevice.CurrentDevice.CheckSystemVersion(9, 0)
                ? view.AtTopOfLayoutGuide(parentView.ReadableContentGuide, margin)
                : view.AtTopOf(parentView, margin);

        public static FluentLayouts.Touch.FluentLayout AtLeftOfLayoutGuide(this UIView view, UILayoutGuide layoutGuide, nfloat? margin = null) =>
            view.Left().EqualTo().LeftOf(layoutGuide).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayouts.Touch.FluentLayout AtLeftOfMargins(this UIView view, UIView parentView, nfloat? margin = null) =>
            UIDevice.CurrentDevice.CheckSystemVersion(11, 0)
                ? AtLeftOfLayoutGuide(view, parentView.LayoutMarginsGuide, margin)
                : view.AtLeftOf(parentView, margin);

        public static FluentLayouts.Touch.FluentLayout AtLeftOfReadableContent(this UIView view, UIView parentView, nfloat? margin = null) =>
            UIDevice.CurrentDevice.CheckSystemVersion(9, 0)
                ? view.AtLeftOfLayoutGuide(parentView.ReadableContentGuide, margin)
                : view.AtLeftOf(parentView, margin);

        public static FluentLayouts.Touch.FluentLayout AtRightOfLayoutGuide(this UIView view, UILayoutGuide layoutGuide, nfloat? margin = null) =>
            view.Right().EqualTo().RightOf(layoutGuide).Minus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayouts.Touch.FluentLayout AtRightOfMargins(this UIView view, UIView parentView, nfloat? margin = null) =>
            UIDevice.CurrentDevice.CheckSystemVersion(11, 0)
                ? view.AtRightOfLayoutGuide(parentView.LayoutMarginsGuide, margin)
                : view.AtRightOf(parentView, margin);

        public static FluentLayouts.Touch.FluentLayout AtRightOfReadableContent(this UIView view, UIView parentView, nfloat? margin = null) =>
            UIDevice.CurrentDevice.CheckSystemVersion(9, 0)
                ? view.AtRightOfLayoutGuide(parentView.ReadableContentGuide, margin)
                : view.AtRightOf(parentView, margin);

        public static FluentLayouts.Touch.FluentLayout WithAspectRatio(this UIView view, nfloat ratio) =>
            view.Height().EqualTo().WidthOf(view).WithMultiplier(ratio);

        public static FluentLayouts.Touch.FluentLayout AtBottomOfLayoutGuide(this UIView view, UILayoutGuide layoutGuide, nfloat? margin = null) =>
            view.Bottom().EqualTo().BottomOf(layoutGuide).Minus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayouts.Touch.FluentLayout AtBottomOfMargins(this UIView view, UIView parentView, nfloat? margin = null) =>
            UIDevice.CurrentDevice.CheckSystemVersion(11, 0)
                ? view.AtBottomOfLayoutGuide(parentView.LayoutMarginsGuide, margin)
                : view.AtBottomOf(parentView, margin);

        public static FluentLayouts.Touch.FluentLayout AtBottomOfReadableContent(this UIView view, UIView parentView, nfloat? margin = null) =>
            UIDevice.CurrentDevice.CheckSystemVersion(9, 0)
                ? view.AtBottomOfLayoutGuide(parentView.ReadableContentGuide, margin)
                : view.AtBottomOf(parentView, margin);
        
        public static FluentLayouts.Touch.FluentLayout[] InsideOfSafeArea(this UIView view,
            UIView parentView,
            nfloat? margin = null)
        {
            return new[]
            {
                view.AtLeftOfSafeArea(parentView, margin),
                view.AtTopOfSafeArea(parentView, margin),
                view.AtBottomOfSafeArea(parentView, margin),
                view.AtRightOfSafeArea(parentView, margin)
            };
        }
        
        public static FluentLayouts.Touch.FluentLayout[] InsideOf(this UIView view,
            UIView parentView,
            nfloat? margin = null)
        {
            return new[]
            {
                view.AtLeftOf(parentView, margin),
                view.AtTopOf(parentView, margin),
                view.AtBottomOf(parentView, margin),
                view.AtRightOf(parentView, margin)
            };
        }
    }
}