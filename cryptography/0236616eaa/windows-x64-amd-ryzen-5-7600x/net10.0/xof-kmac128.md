| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128B         |   3.120 μs | 0.0054 μs | 0.0042 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128B         |   3.968 μs | 0.0114 μs | 0.0095 μs |   8,887 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128B         |   5.072 μs | 0.0075 μs | 0.0063 μs |  13,883 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 1KB          |   4.301 μs | 0.0177 μs | 0.0148 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 1KB          |   5.433 μs | 0.0116 μs | 0.0103 μs |   9,969 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 1KB          |   6.903 μs | 0.0082 μs | 0.0069 μs |  13,912 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 8KB          |  12.644 μs | 0.0876 μs | 0.0732 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 8KB          |  15.715 μs | 0.0325 μs | 0.0271 μs |  10,006 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 8KB          |  19.736 μs | 0.0681 μs | 0.0569 μs |  13,927 B |     128 B |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · KMAC-128 · CryptoHives-Scalar | 128KB        | 157.257 μs | 0.2760 μs | 0.2155 μs |        NA |         - |
| AbsorbSqueeze · KMAC-128 · OS Native          | 128KB        | 193.981 μs | 0.2914 μs | 0.2584 μs |   9,989 B |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle       | 128KB        | 242.229 μs | 0.2436 μs | 0.2160 μs |  13,949 B |     128 B |