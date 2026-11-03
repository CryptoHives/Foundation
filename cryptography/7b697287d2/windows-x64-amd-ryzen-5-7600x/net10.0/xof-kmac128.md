| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   3.507 μs | 0.0056 μs | 0.0050 μs |   7,287 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   4.453 μs | 0.0138 μs | 0.0129 μs |  11,270 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   5.808 μs | 0.0084 μs | 0.0074 μs |  14,591 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   4.870 μs | 0.0151 μs | 0.0141 μs |   7,286 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |   6.115 μs | 0.0304 μs | 0.0254 μs |  11,323 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   7.751 μs | 0.0287 μs | 0.0268 μs |  14,615 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  14.326 μs | 0.1119 μs | 0.0992 μs |   7,286 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  17.782 μs | 0.1170 μs | 0.1094 μs |  10,694 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  22.321 μs | 0.1250 μs | 0.1169 μs |  14,615 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 177.124 μs | 0.4370 μs | 0.3874 μs |   7,288 B |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 218.372 μs | 0.2854 μs | 0.2670 μs |  11,289 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 273.461 μs | 0.4167 μs | 0.3694 μs |  14,645 B |     128 B |