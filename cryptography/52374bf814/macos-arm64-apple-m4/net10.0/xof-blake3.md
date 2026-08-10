| Description                           | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Native       | 128B         |   1.614 μs | 0.0057 μs | 0.0054 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 128B         |   8.713 μs | 0.0430 μs | 0.0381 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 128B         |  11.363 μs | 0.0418 μs | 0.0391 μs |      56 B |
|                                       |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 1KB          |   2.291 μs | 0.0113 μs | 0.0094 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 1KB          |  12.245 μs | 0.0468 μs | 0.0415 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 1KB          |  17.047 μs | 0.3394 μs | 0.3485 μs |      56 B |
|                                       |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 8KB          |   7.306 μs | 0.0066 μs | 0.0055 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 8KB          |  42.989 μs | 0.2234 μs | 0.1981 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 8KB          |  54.492 μs | 0.0106 μs | 0.0094 μs |      56 B |
|                                       |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 128KB        |  93.232 μs | 0.0389 μs | 0.0364 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 128KB        | 543.771 μs | 2.5659 μs | 2.4001 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 128KB        | 690.745 μs | 2.0506 μs | 1.9181 μs |      56 B |