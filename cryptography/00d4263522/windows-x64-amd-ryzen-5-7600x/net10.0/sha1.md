| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SHA-1 · OS Native          | 128B         |     236.8 ns |   0.52 ns |   0.46 ns |   4,352 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128B         |     451.6 ns |   0.91 ns |   0.86 ns |   7,067 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128B         |     472.0 ns |   1.01 ns |   0.94 ns |   4,716 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 137B         |     236.9 ns |   0.88 ns |   0.78 ns |   4,352 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 137B         |     448.9 ns |   0.56 ns |   0.47 ns |   7,059 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 137B         |     470.5 ns |   0.73 ns |   0.65 ns |   4,724 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1KB          |   1,134.5 ns |   2.84 ns |   2.51 ns |   4,280 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1KB          |   2,508.3 ns |  10.77 ns |   9.54 ns |   7,064 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1KB          |   2,535.7 ns |   7.39 ns |   6.55 ns |   4,713 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 1025B        |   1,135.6 ns |   3.07 ns |   2.87 ns |   4,352 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 1025B        |   2,501.4 ns |   5.45 ns |   4.83 ns |   7,064 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 1025B        |   2,534.8 ns |   7.91 ns |   7.01 ns |   4,721 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 8KB          |   8,301.9 ns |  15.17 ns |  13.45 ns |   4,352 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 8KB          |  18,872.8 ns |  39.59 ns |  37.03 ns |   7,078 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 8KB          |  19,032.0 ns | 104.41 ns |  87.19 ns |   4,713 B |         - |
|                                             |              |              |           |           |           |           |
| TryComputeHash · SHA-1 · OS Native          | 128KB        | 131,614.7 ns | 273.35 ns | 228.26 ns |   4,352 B |         - |
| TryComputeHash · SHA-1 · BouncyCastle       | 128KB        | 300,357.7 ns | 435.69 ns | 363.82 ns |   7,019 B |         - |
| TryComputeHash · SHA-1 · CryptoHives-Scalar | 128KB        | 301,350.2 ns | 466.12 ns | 389.23 ns |   4,734 B |         - |