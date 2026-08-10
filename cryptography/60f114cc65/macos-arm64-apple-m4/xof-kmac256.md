| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 128B         |   3.023 μs | 0.0075 μs | 0.0066 μs |     128 B |
| AbsorbSqueeze · KMAC-256 · Managed      | 128B         |   3.098 μs | 0.0046 μs | 0.0041 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 1KB          |   4.177 μs | 0.0133 μs | 0.0125 μs |    1248 B |
| AbsorbSqueeze · KMAC-256 · Managed      | 1KB          |   4.806 μs | 0.0088 μs | 0.0078 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 8KB          |  12.802 μs | 0.0151 μs | 0.0141 μs |    9728 B |
| AbsorbSqueeze · KMAC-256 · Managed      | 8KB          |  18.012 μs | 0.0262 μs | 0.0245 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 128KB        | 159.815 μs | 0.2567 μs | 0.2402 μs |  154208 B |
| AbsorbSqueeze · KMAC-256 · Managed      | 128KB        | 243.783 μs | 0.1222 μs | 0.1084 μs |         - |