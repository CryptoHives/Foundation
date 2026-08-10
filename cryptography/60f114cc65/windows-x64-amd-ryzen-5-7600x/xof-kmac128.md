| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · Managed      | 128B         |   3.177 μs | 0.0190 μs | 0.0168 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native    | 128B         |   3.892 μs | 0.0484 μs | 0.0452 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 128B         |   5.050 μs | 0.0365 μs | 0.0341 μs |     128 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · Managed      | 1KB          |   4.924 μs | 0.0628 μs | 0.0557 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native    | 1KB          |   5.344 μs | 0.0611 μs | 0.0542 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 1KB          |   6.978 μs | 0.0478 μs | 0.0447 μs |    1280 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · OS Native    | 8KB          |  15.438 μs | 0.1537 μs | 0.1438 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · Managed      | 8KB          |  17.515 μs | 0.1049 μs | 0.0930 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 8KB          |  20.503 μs | 0.0990 μs | 0.0826 μs |    9344 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · OS Native    | 128KB        | 191.110 μs | 1.2208 μs | 0.9531 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · Managed      | 128KB        | 236.513 μs | 1.4647 μs | 1.3701 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 128KB        | 256.988 μs | 2.0278 μs | 1.6933 μs |  149888 B |