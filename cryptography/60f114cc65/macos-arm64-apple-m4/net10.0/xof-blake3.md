| Description                           | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Native       | 128B         |   1.645 μs | 0.0016 μs | 0.0014 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 128B         |   8.986 μs | 0.0534 μs | 0.0500 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 128B         |  11.627 μs | 0.0305 μs | 0.0238 μs |      56 B |
|                                       |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 1KB          |   2.273 μs | 0.0012 μs | 0.0011 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 1KB          |  12.542 μs | 0.0444 μs | 0.0415 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 1KB          |  16.668 μs | 0.0679 μs | 0.0602 μs |      56 B |
|                                       |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 8KB          |   7.289 μs | 0.0023 μs | 0.0022 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 8KB          |  41.226 μs | 0.1944 μs | 0.1819 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 8KB          |  53.869 μs | 0.1583 μs | 0.1481 μs |      56 B |
|                                       |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 128KB        |  93.325 μs | 0.0727 μs | 0.0680 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 128KB        | 534.477 μs | 2.6038 μs | 2.4356 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 128KB        | 689.720 μs | 1.5110 μs | 1.4134 μs |      56 B |