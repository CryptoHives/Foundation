| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 128B         |   2.595 μs | 0.0110 μs | 0.0097 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · Managed      | 128B         |   2.647 μs | 0.0048 μs | 0.0045 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 1KB          |   3.599 μs | 0.0063 μs | 0.0059 μs |    1280 B |
| AbsorbSqueeze · KMAC-128 · Managed      | 1KB          |   4.211 μs | 0.0033 μs | 0.0028 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 8KB          |  10.580 μs | 0.0185 μs | 0.0173 μs |    9344 B |
| AbsorbSqueeze · KMAC-128 · Managed      | 8KB          |  15.795 μs | 0.0067 μs | 0.0059 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 128KB        | 132.530 μs | 0.1658 μs | 0.1470 μs |  149888 B |
| AbsorbSqueeze · KMAC-128 · Managed      | 128KB        | 216.622 μs | 0.1499 μs | 0.1329 μs |         - |