#!/usr/bin/env Rscript
# Generate a comparison chart showing throughput of all CryptoHives implementations
# Shows the fastest CryptoHives implementation per algorithm
# Usage: Rscript generate-comparison-chart.R <results_dir> <output_file> [size]
# Example: Rscript generate-comparison-chart.R ./results comparison.png 1KB

suppressPackageStartupMessages({
  library(ggplot2)
  library(dplyr)
  library(stringr)
})

args <- commandArgs(trailingOnly = TRUE)
if (length(args) < 2) {
  cat("Usage: Rscript generate-comparison-chart.R <results_dir> <output_file> [size]\n")
  cat("  results_dir: Directory containing *Benchmark-report.md files\n")
  cat("  output_file: Output PNG file path\n")
  cat("  size: Data size to filter (default: 1KB)\n")
  quit(status = 1)
}

results_dir <- args[1]
output_file <- args[2]
target_size <- if (length(args) >= 3) args[3] else "1KB"

# CryptoHives implementations (our own code, not third-party)
cryptohives_impls <- c("Managed", "AVX2", "AVX512F", "Ssse3", "Sse2", "Native")

cat(sprintf("Scanning directory: %s\n", results_dir))
cat(sprintf("Target size: %s\n", target_size))

# Find all benchmark markdown files
md_files <- list.files(results_dir, pattern = "Benchmark-report\\.md$", full.names = TRUE)
cat(sprintf("Found %d benchmark files\n", length(md_files)))

if (length(md_files) == 0) {
  cat("No benchmark files found!\n")
  quit(status = 1)
}

# Function to extract algorithm name from filename
extract_algorithm <- function(filename) {
  basename <- tools::file_path_sans_ext(basename(filename))
  # Remove "Benchmark-report" suffix
  algo <- str_replace(basename, "-report$", "")
  algo <- str_replace(algo, "Benchmark$", "")
  return(algo)
}

# Function to parse markdown table from a file
parse_markdown_file <- function(filepath) {
  lines <- readLines(filepath, warn = FALSE)
  
  # Find table header (use character class [|] instead of \\| for literal pipe)
  header_idx <- which(grepl("^[|].*Description.*Mean", lines, perl = TRUE))
  if (length(header_idx) == 0) {
    return(NULL)
  }
  header_idx <- header_idx[1]
  
  # Parse header
  header_line <- lines[header_idx]
  headers <- str_trim(str_split(header_line, fixed("|"))[[1]])
  headers <- headers[headers != ""]
  
  # Find data rows (skip separator line)
  data_start <- header_idx + 2
  data_rows <- c()
  for (i in data_start:length(lines)) {
    line <- lines[i]
    if (!grepl("^[|]", line, perl = TRUE)) break
    if (grepl("^[|]-", line, perl = TRUE)) next
    data_rows <- c(data_rows, line)
  }
  
  if (length(data_rows) == 0) {
    return(NULL)
  }
  
  # Parse data rows
  parse_row <- function(row) {
    cells <- str_trim(str_split(row, fixed("|"))[[1]])
    cells <- cells[cells != ""]
    if (length(cells) >= length(headers)) {
      return(cells[1:length(headers)])
    }
    return(NULL)
  }
  
  parsed <- lapply(data_rows, parse_row)
  parsed <- parsed[!sapply(parsed, is.null)]
  
  if (length(parsed) == 0) {
    return(NULL)
  }
  
  df <- as.data.frame(do.call(rbind, parsed), stringsAsFactors = FALSE)
  colnames(df) <- headers
  
  return(df)
}

# Function to extract implementation from description
get_implementation <- function(desc) {
  # Handle "Method · Algorithm · Implementation" format
  if (str_detect(desc, "·")) {
    parts <- str_trim(str_split(desc, "·")[[1]])
    if (length(parts) >= 3) {
      return(parts[3])
    }
  }
  # Handle underscore format like "Kmac128_CryptoHives"
  if (str_detect(desc, "_")) {
    parts <- str_split(desc, "_")[[1]]
    if (length(parts) >= 2) {
      impl <- parts[length(parts)]
      if (impl == "DotNet") return("OS Native")
      return(impl)
    }
  }
  return("Unknown")
}

# Function to parse time string to nanoseconds
parse_time_ns <- function(time_str) {
  time_str <- str_trim(time_str)
  # Remove commas from numbers (e.g., "2,851.9 ns" -> "2851.9 ns")
  time_str <- gsub(",", "", time_str)
  
  if (str_detect(time_str, "ns$")) {
    return(as.numeric(str_replace(time_str, " ?ns$", "")))
  } else if (str_detect(time_str, "μs$") || str_detect(time_str, "us$")) {
    return(as.numeric(str_replace(time_str, " ?(μs|us)$", "")) * 1000)
  } else if (str_detect(time_str, "ms$")) {
    return(as.numeric(str_replace(time_str, " ?ms$", "")) * 1000000)
  } else if (str_detect(time_str, "s$")) {
    return(as.numeric(str_replace(time_str, " ?s$", "")) * 1000000000)
  }
  return(NA)
}

# Function to parse size to bytes
parse_size_bytes <- function(size_str) {
  size_str <- str_trim(size_str)
  
  if (str_detect(size_str, "KB$")) {
    return(as.numeric(str_replace(size_str, "KB$", "")) * 1024)
  } else if (str_detect(size_str, "MB$")) {
    return(as.numeric(str_replace(size_str, "MB$", "")) * 1024 * 1024)
  } else if (str_detect(size_str, "B$")) {
    return(as.numeric(str_replace(size_str, "B$", "")))
  }
  return(as.numeric(size_str))
}

# Collect data from all files
all_data <- data.frame()

for (md_file in md_files) {
  algo_name <- extract_algorithm(md_file)
  df <- parse_markdown_file(md_file)
  
  if (is.null(df)) {
    cat(sprintf("  Skipping %s (no valid table)\n", basename(md_file)))
    next
  }
  
  # Find the size column
  size_col <- names(df)[str_detect(tolower(names(df)), "size|data")]
  if (length(size_col) == 0) {
    cat(sprintf("  Skipping %s (no size column)\n", basename(md_file)))
    next
  }
  size_col <- size_col[1]
  
  # Find Mean column
  mean_col <- names(df)[str_detect(names(df), "^Mean$")]
  if (length(mean_col) == 0) {
    cat(sprintf("  Skipping %s (no Mean column)\n", basename(md_file)))
    next
  }
  
  # Add algorithm name and process
  df$Algorithm <- algo_name
  df$Implementation <- sapply(df$Description, get_implementation)
  df$SizeBytes <- sapply(df[[size_col]], parse_size_bytes)
  df$MeanNs <- sapply(df[[mean_col]], parse_time_ns)
  df$TargetSize <- df[[size_col]]
  
  all_data <- rbind(all_data, df[, c("Algorithm", "Implementation", "TargetSize", "SizeBytes", "MeanNs")])
}

cat(sprintf("Collected %d total rows\n", nrow(all_data)))

# Filter to target size and CryptoHives implementations
filtered <- all_data %>%
  filter(TargetSize == target_size, Implementation %in% cryptohives_impls) %>%
  filter(!is.na(MeanNs), MeanNs > 0)

cat(sprintf("After filtering CryptoHives implementations: %d rows\n", nrow(filtered)))

if (nrow(filtered) == 0) {
  cat("No data matches the filter criteria!\n")
  cat(sprintf("Available sizes: %s\n", paste(unique(all_data$TargetSize), collapse = ", ")))
  cat(sprintf("Available implementations: %s\n", paste(unique(all_data$Implementation), collapse = ", ")))
  quit(status = 1)
}

# Calculate throughput
filtered <- filtered %>%
  mutate(ThroughputMBps = (SizeBytes / MeanNs) * 1000)

# Find fastest CryptoHives implementation per algorithm
fastest_cryptohives <- filtered %>%
  group_by(Algorithm) %>%
  slice_max(ThroughputMBps, n = 1) %>%
  ungroup() %>%
  mutate(Source = "CryptoHives")

cat(sprintf("Fastest CryptoHives per algorithm: %d\n", nrow(fastest_cryptohives)))

# Now find if any third-party is faster for each algorithm
third_party_impls <- c("OS Native", "BouncyCastle", "OpenGost", "Hashify .NET")

third_party <- all_data %>%
  filter(TargetSize == target_size, Implementation %in% third_party_impls) %>%
  filter(!is.na(MeanNs), MeanNs > 0) %>%
  mutate(ThroughputMBps = (SizeBytes / MeanNs) * 1000)

# Find fastest third-party per algorithm (only if faster than CryptoHives)
faster_third_party <- third_party %>%
  group_by(Algorithm) %>%
  slice_max(ThroughputMBps, n = 1) %>%
  ungroup() %>%
  inner_join(fastest_cryptohives %>% select(Algorithm, CryptoHivesThroughput = ThroughputMBps), 
             by = "Algorithm") %>%
  filter(ThroughputMBps > CryptoHivesThroughput) %>%
  select(-CryptoHivesThroughput) %>%
  mutate(Source = Implementation)

cat(sprintf("Faster third-party implementations: %d\n", nrow(faster_third_party)))

# Combine: CryptoHives + faster third-party
chart_data <- bind_rows(fastest_cryptohives, faster_third_party)

# Determine unit based on chart_data
max_throughput <- max(chart_data$ThroughputMBps, na.rm = TRUE)
if (max_throughput >= 1000) {
  throughput_unit <- "GB/s"
  chart_data$Throughput <- chart_data$ThroughputMBps / 1000
} else {
  throughput_unit <- "MB/s"
  chart_data$Throughput <- chart_data$ThroughputMBps
}

cat(sprintf("Using throughput unit: %s (max: %.2f MB/s)\n", throughput_unit, max_throughput))

# Sort by throughput descending (CryptoHives first for each algo)
chart_data <- chart_data %>%
  arrange(Algorithm, desc(Source == "CryptoHives"), desc(Throughput))

# Create unique labels for algorithms with multiple bars
chart_data <- chart_data %>%
  mutate(Label = if_else(Source == "CryptoHives", Algorithm, paste0(Algorithm, " (", Source, ")")))

# Order by CryptoHives throughput
algo_order <- fastest_cryptohives %>%
  arrange(desc(ThroughputMBps)) %>%
  pull(Algorithm)

chart_data$Algorithm <- factor(chart_data$Algorithm, levels = algo_order)

# Define colors: CryptoHives = blue shades, others = different colors
chart_data <- chart_data %>%
  mutate(FillGroup = if_else(Source == "CryptoHives", "CryptoHives", Source))

# Generate chart
p <- ggplot(chart_data, aes(x = Algorithm, y = Throughput, fill = FillGroup)) +
  geom_bar(stat = "identity", position = position_dodge(width = 0.8), width = 0.7) +
  geom_text(aes(label = sprintf("%.1f", Throughput), group = FillGroup), 
            position = position_dodge(width = 0.8),
            vjust = -0.3, size = 3, fontface = "bold") +
  labs(
    title = "Hash Algorithm Throughput Comparison",
    subtitle = sprintf("Data size: %s | Fastest CryptoHives vs faster third-party | Higher is better", target_size),
    x = "Algorithm",
    y = sprintf("Throughput (%s)", throughput_unit),
    fill = "Implementation"
  ) +
  scale_fill_manual(values = c(
    "CryptoHives" = "#4E79A7",
    "OS Native" = "#E15759",
    "BouncyCastle" = "#F28E2B",
    "OpenGost" = "#76B7B2",
    "Hashify .NET" = "#59A14F"
  )) +
  theme_minimal(base_size = 12) +
  theme(
    plot.title = element_text(hjust = 0.5, face = "bold", size = 16),
    plot.subtitle = element_text(hjust = 0.5, size = 12, color = "gray40"),
    axis.text.x = element_text(angle = 45, hjust = 1, size = 10),
    axis.title = element_text(face = "bold"),
    legend.position = "top",
    panel.grid.major.x = element_blank(),
    panel.grid.minor = element_blank(),
    panel.border = element_rect(color = "gray80", fill = NA, linewidth = 0.5)
  )

# Save plot
cat(sprintf("Saving chart to: %s\n", output_file))
ggsave(output_file, plot = p, width = 14, height = 8, dpi = 300, bg = "white")

cat(sprintf("✓ Comparison chart generated with %d data points!\n", nrow(chart_data)))
