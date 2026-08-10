| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   2.594 μs | 0.0128 μs | 0.0113 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   2.640 μs | 0.0026 μs | 0.0020 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   3.606 μs | 0.0304 μs | 0.0285 μs |    1280 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   4.210 μs | 0.0067 μs | 0.0063 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  10.595 μs | 0.0347 μs | 0.0271 μs |    9344 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  15.837 μs | 0.0502 μs | 0.0419 μs |         - |
|                                               |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 132.775 μs | 0.5396 μs | 0.4213 μs |  149888 B |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 216.998 μs | 0.4419 μs | 0.3450 μs |         - |