// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Drawing.Drawing2D
{
    // FlushIntentionFlush merely means that all the pending commands have been passed to
    // the hardware, and that the final results will be shown as soon as the hardware finishes
    // its rendering.  FlushIntentionSync means to wait for the hardware to actually finish its
    // rendering before returning - this is important for animation and timing loops.

    /// <summary>
    /// Specifies whether commands in the graphics stack are terminated (flushed) immediately or executed as soon as possible.
    /// </summary>
    public enum FlushIntention
    {
        /// <summary>
        /// Specifies the stack of all graphics operations is flushed immediately.
        /// </summary>
        Flush = 0,

        /// <summary>
        /// Specifies that all graphics operations on the stack are execyted as soon as possible. This synchronizes the graphics state.
        /// </summary>
        Sync = 1
    }
}
