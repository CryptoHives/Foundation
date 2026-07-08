# EmptySegment&lt;T&gt; Class

An [`ISegmentOwner<T>`](isegmentowner.md) that represents an empty, zero-allocation segment
backed by `Array.Empty<T>()`. Useful as a null-object sentinel that avoids `null` checks.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Buffers
```

## Inheritance

`Object` → **`EmptySegment<T>`**

## Implements

- [`ISegmentOwner<T>`](isegmentowner.md)
- `IDisposable`

## Syntax

```csharp
public sealed class EmptySegment<T> : ISegmentOwner<T>
```

## Overview

`EmptySegment<T>` follows the null-object pattern: it satisfies the `ISegmentOwner<T>`
contract without allocating any array. All index access throws, `TrySetSegment` always
returns `false`, and `Dispose` is a no-op.

The singleton `Instance` property returns the single shared instance — no allocation is
ever needed.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Instance` | `ISegmentOwner<T>` | The shared empty segment singleton |
| `Segment` | `ArraySegment<T>` | Always an empty segment (`Count == 0`, `Offset == 0`) |

## Methods

| Method | Description |
|--------|-------------|
| `bool TrySetSegment(int offset, int length)` | Always returns `false`; an empty segment cannot be resized |
| `void Dispose()` | No-op; safe to call any number of times |

## Usage Examples

### Default / Uninitialized State

```csharp
using CryptoHives.Foundation.Memory.Buffers;

public class Pipeline
{
    private ISegmentOwner<byte> _segment = EmptySegment<byte>.Instance;

    public void Setsegment(ISegmentOwner<byte> segment)
    {
        _segment = segment;
    }

    public void Run()
    {
        // No null check needed — EmptySegment.Segment.Count == 0
        if (_segment.Segment.Count == 0)
            return;

        Span<byte> data = _segment.Segment.AsSpan();
        // ...
    }
}
```

### Guard Against Null segment Parameters

```csharp
void Process(ISegmentOwner<byte> segment)
{
    // Accept EmptySegment as a valid "nothing to do" signal
    if (segment.Segment.Count == 0)
        return;

    // ...
}

// Call with an explicit empty segment — no null reference risk
Process(EmptySegment<byte>.Instance);
```

## Remarks

- Accessing the indexer (`this[int]`) always throws `ArgumentOutOfRangeException`; the
  segment is empty and has no elements.
- `TrySetSegment` always returns `false` regardless of arguments; the empty segment
  intentionally cannot be resized.
- The singleton `Instance` is created once and reused — use it freely without allocation
  concern.

## See Also

- [`ISegmentOwner<T>`](isegmentowner.md)
- [`PooledSegment<T>`](pooledsegment.md)
- [`AllocatedSegment<T>`](allocatedsegment.md)
- [Memory Package Overview](index.md)

---

© 2026 The Keepers of the CryptoHives


