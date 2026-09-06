# EmptySequence&lt;T&gt; Class

An [`ISequenceOwner<T>`](isequenceowner.md) representing an empty, zero-allocation sequence backed by
`ReadOnlySequence<T>.Empty`. Follows the null-object pattern to keep `null` checks out of consumers,
mirroring [`EmptySegment<T>`](emptysegment.md) on the segment side.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Buffers
```

## Inheritance

`Object` → **`EmptySequence<T>`**

## Implements

- [`ISequenceOwner<T>`](isequenceowner.md)
- `IDisposable`

## Syntax

```csharp
public sealed class EmptySequence<T> : ISequenceOwner<T>
```

## Members

| Member | Type | Description |
|--------|------|-------------|
| `Instance` | `ISequenceOwner<T>` (static) | The shared singleton. No allocation is ever needed. |
| `Sequence` | `ReadOnlySequence<T>` | Always `ReadOnlySequence<T>.Empty` |
| `Length` | `long` | Always `0` |
| `IsEmpty` | `bool` | Always `true` |
| `Dispose()` | `void` | No-op |

## Where It Comes From

This is what a producer hands back when there is nothing to own, so callers can always write `using`
over the result of a detach without a null test:

```csharp
using var writer = new ArrayPoolBufferWriter<byte>();

// Nothing was written
ISequenceOwner<byte> owned = PayloadOrNothing();

owned.IsEmpty;                                       // true
ReferenceEquals(owned, EmptySequence<byte>.Instance) // true — no allocation
```

## Disposal Is Safe Anywhere

The singleton owns nothing, so disposing it has no effect — including repeatedly, and from several
callers at once. That is what makes it safe to return the same instance to every caller.

```csharp
ISequenceOwner<byte> none = EmptySequence<byte>.Instance;

none.Dispose();
none.Dispose();   // still fine
```

## Usage

### Avoiding a null branch

```csharp
ISequenceOwner<byte> Payload(bool hasData) =>
    hasData ? BuildPayload() : EmptySequence<byte>.Instance;

using ISequenceOwner<byte> owned = Payload(condition);

// No null check needed; an empty sequence simply yields nothing
foreach (ReadOnlyMemory<byte> segment in owned.Sequence)
{
    Process(segment);
}
```

## Thread Safety

**Thread-safe.** The singleton is immutable and its `Dispose` does nothing, so it can be shared
freely across threads.

## See Also

- [ISequenceOwner&lt;T&gt;](isequenceowner.md)
- [SegmentSequence&lt;T&gt;](segmentsequence.md)
- [EmptySegment&lt;T&gt;](emptysegment.md)
- [Memory Package Overview](index.md)

---

© 2026 The Keepers of the CryptoHives
