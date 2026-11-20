| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| ComputeMac · HMAC-SHA256 · OS                 | 128B         |   1.136 μs | 0.0008 μs | 0.0006 μs |  12,631 B |     320 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128B         |   1.729 μs | 0.0077 μs | 0.0064 μs |   4,878 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128B         |   1.842 μs | 0.0056 μs | 0.0050 μs |   5,922 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 137B         |   1.140 μs | 0.0007 μs | 0.0007 μs |   8,786 B |     336 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 137B         |   1.730 μs | 0.0118 μs | 0.0104 μs |   4,878 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 137B         |   1.854 μs | 0.0052 μs | 0.0047 μs |   9,955 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1KB          |   3.778 μs | 0.0041 μs | 0.0038 μs |  12,819 B |    1216 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1KB          |   5.543 μs | 0.0157 μs | 0.0122 μs |   4,876 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1KB          |   8.048 μs | 0.0507 μs | 0.0450 μs |   9,767 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 1025B        |   3.766 μs | 0.0019 μs | 0.0015 μs |  12,650 B |    1224 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 1025B        |   5.867 μs | 0.0416 μs | 0.0389 μs |   4,887 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 1025B        |   8.041 μs | 0.0675 μs | 0.0631 μs |   9,763 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 8KB          |  24.079 μs | 0.0348 μs | 0.0325 μs |  12,670 B |    8384 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 8KB          |  36.048 μs | 0.4031 μs | 0.3771 μs |   4,878 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 8KB          |  56.405 μs | 0.3293 μs | 0.3080 μs |   5,920 B |         - |
|                                               |              |            |           |           |           |           |
| ComputeMac · HMAC-SHA256 · OS                 | 128KB        | 441.707 μs | 0.2708 μs | 0.2400 μs |  12,670 B |  131318 B |
| ComputeMac · HMAC-SHA256 · CryptoHives-Scalar | 128KB        | 553.955 μs | 3.9055 μs | 3.2613 μs |   4,887 B |         - |
| ComputeMac · HMAC-SHA256 · BouncyCastle       | 128KB        | 900.701 μs | 2.1128 μs | 1.8730 μs |   9,957 B |         - |