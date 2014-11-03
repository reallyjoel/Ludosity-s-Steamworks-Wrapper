using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// SendP2PPacket() send types
    /// Typically k_EP2PSendUnreliable is what you want for UDP-like packets, k_EP2PSendReliable 
    /// for TCP-like packets
    /// 
    /// Managed version of the \a EP2PSend enum
    /// </summary>
    public enum P2PSend
    {
        /// <summary>
        /// Basic UDP send. Packets can't be bigger than 1200 bytes (your typical MTU size). Can be lost, or arrive out of order (rare).
        /// The sending API does have some knowledge of the underlying connection, so if there is no NAT-traversal accomplished or
        /// there is a recognized adjustment happening on the connection, the packet will be batched until the connection is open again.
        /// </summary>
        Unreliable = 0,

        /// <summary>
        /// As above, but if the underlying p2p connection isn't yet established the packet will just be thrown away. Using this on the first
        /// packet sent to a remote host almost guarantees the packet will be dropped.
        /// This is only really useful for kinds of data that should never buffer up, i.e. voice payload packets
        /// </summary>
        UnreliableNoDelay = 1,

        /// <summary>
        /// Reliable message send. Can send up to 1MB of data in a single message. 
        /// Does fragmentation/re-assembly of messages under the hood, as well as a sliding window for efficient sends of large chunks of data. 
        /// </summary>
        Reliable = 2,

        /// <summary>
        /// As above, but applies the Nagle algorithm to the send - sends will accumulate 
        /// until the current MTU size (typically ~1200 bytes, but can change) or ~200ms has passed (Nagle algorithm). 
        /// Useful if you want to send a set of smaller messages but have the coalesced into a single packet
        /// Since the reliable stream is all ordered, you can do several small message sends with k_EP2PSendReliableWithBuffering and then
        /// do a normal k_EP2PSendReliable to force all the buffered data to be sent.
        /// </summary>
        ReliableWithBuffering = 3,
    }

}
