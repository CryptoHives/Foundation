| Description                           | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Native       | 128B         |     1.573 μs | 0.0038 μs | 0.0035 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 128B         |     2.347 μs | 0.0060 μs | 0.0056 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 128B         |     9.110 μs | 0.0258 μs | 0.0241 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 128B         |    19.425 μs | 0.0801 μs | 0.0749 μs |      56 B |
|                                       |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 1KB          |     2.147 μs | 0.0049 μs | 0.0045 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 1KB          |     3.221 μs | 0.0048 μs | 0.0040 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 1KB          |    12.832 μs | 0.0422 μs | 0.0395 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 1KB          |    28.551 μs | 0.0594 μs | 0.0556 μs |      56 B |
|                                       |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 8KB          |     6.633 μs | 0.0225 μs | 0.0188 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 8KB          |    10.253 μs | 0.0378 μs | 0.0354 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 8KB          |    42.312 μs | 0.0701 μs | 0.0547 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 8KB          |    97.889 μs | 0.1732 μs | 0.1535 μs |      56 B |
|                                       |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Native       | 128KB        |    84.243 μs | 1.2971 μs | 1.1499 μs |         - |
| AbsorbSqueeze · BLAKE3 · Ssse3        | 128KB        |   127.910 μs | 0.2692 μs | 0.2386 μs |         - |
| AbsorbSqueeze · BLAKE3 · Managed      | 128KB        |   549.115 μs | 1.2543 μs | 1.1119 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle | 128KB        | 1,318.038 μs | 2.7657 μs | 2.4517 μs |      56 B |